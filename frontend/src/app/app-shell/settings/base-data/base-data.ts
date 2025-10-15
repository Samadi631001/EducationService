import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { AgGridAngular } from 'ag-grid-angular';
import { ColDef, GridApi, GridOptions } from 'ag-grid-community';
import { BaseDataService } from '../../../services/basedata-service';
import { BaseDataDto } from '../../../core/models/BaseDataDto';
import { BaseDataCellActionsComponent } from './baseDataCell';
import { SwalService } from '../../../services/framework-services/swal.service';
import { AgGridBaseComponent } from '../../../shared/ag-grid-base/ag-grid-base';
import { LabelButtonComponent } from '../../../shared/custom-buttons/label-button';
import { CustomInputComponent } from '../../../shared/custom-controls/custom-input';
import { ModalComponent } from '../../../shared/modal/modal';

@Component({
  selector: 'app-base-data',
  standalone: true,
  imports: [
    ModalComponent,
    CustomInputComponent,
    LabelButtonComponent,
    ReactiveFormsModule,
    AgGridAngular,
    BaseDataCellActionsComponent
  ],
  templateUrl: './base-data.html',
  styleUrls: ['./base-data.css']
})
export class BaseDataComponent extends AgGridBaseComponent implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly fb = inject(FormBuilder);
  private readonly baseDataService = inject(BaseDataService);
  private readonly swalService = inject(SwalService);
  form: FormGroup;
  type: string | null = null;
  records: BaseDataDto[] = [];
  isEditMode = false;
  session: { title: string; comment: string } = { title: '', comment: '' };

  constructor() {
    super();
    this.form = this.fb.group({
      id: [0],
      title: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
      comment: ['', Validators.maxLength(1000)],
      baseDataTypeId: [0]
    });
  }

  override ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      this.type = params.get('type');
      if (this.type) {
        this.form.patchValue({ baseDataTypeId: parseInt(this.type) });
      } else {
        this.swalService.fireSwal('نوع داده معتبر نیست!');
      }
    });

    this.setupGridColumns();
  }

  override onGridReady(params: any): void {
    this.gridApi = params.api;
    console.log('Grid API initialized:', this.gridApi); // برای دیباگ
    if (this.type) {
      this.getRecords();
    }
  }

  private setupGridColumns(): void {
    this.gridOptions().columnDefs = [
      {
        headerName: 'عملیات',
        cellRenderer: BaseDataCellActionsComponent,
        cellRendererParams: {
          onEdit: (rowData: BaseDataDto) => this.openModal(rowData),
          onDelete: (rowData: BaseDataDto) => this.askForDelete(rowData.id)
        },
        minWidth: 180,
        sortable: false,
        filter: false
      },
      {
        field: 'rowNumber',
        headerName: 'ردیف',
        valueGetter: 'node.rowIndex + 1',
        sortable: false,
        filter: false,
        minWidth: 80
      },
      { field: 'title', headerName: 'عنوان' },
      { field: 'comment', headerName: 'توضیحات' },
      { field: 'created', headerName: 'تاریخ ایجاد' },
      { field: 'status', headerName: 'وضعیت' }
    ];
  }

  getRecords(): void {
    if (!this.type) {
      this.swalService.fireSwal('نوع داده معتبر نیست!');
      return;
    }

    this.baseDataService.getListBy(this.type).subscribe({
      next: (data: BaseDataDto[]) => {
        console.log('Records received:', data);
        this.records = data;
        if (this.gridApi) {
          this.gridApi().setGridOption('rowData', this.records); // جایگزین setRowData
        }
      },
      error: (err) => {
        console.error('Error loading records:', err);
        this.swalService.fireSwal('خطا در بارگذاری داده‌ها!');
      }
    });
  }

  openModal(editData?: BaseDataDto): void {
    console.log('Opening modal, gridApi:', this.gridApi); // برای دیباگ
    if (editData) {
      this.isEditMode = true;
      this.session = { title: editData.title, comment: editData.comment };
      this.baseDataService.getForEdit<BaseDataDto>(editData.id).subscribe({
        next: (data) => {
          this.form.patchValue({
            id: data.id,
            title: data.title,
            comment: data.comment
          });
        }
      });
    } else {
      this.isEditMode = false;
      this.session = { title: '', comment: '' };
      this.form.reset({ id: 0, baseDataTypeId: this.type ? parseInt(this.type) : 0 });
    }

    const modalElement = document.getElementById('sessionModal');
    if (modalElement) {
      const modal = new window.bootstrap.Modal(modalElement);
      modal.show();
    }
  }

  onSubmit(): void {
    // if (this.form.invalid) {
    //   this.swalService.fireSwal('لطفاً فرم را به درستی پر کنید!');
    //   return;
    // }

    const model = this.form.value;
    const operation = this.isEditMode
      ? this.baseDataService.edit(model)
      : this.baseDataService.create(model);

    operation.subscribe({
      next: () => {
        this.closeModal();
        this.getRecords();
      },
      error: (err) => {
        console.error('Error saving record:', err);
        this.swalService.fireSwal('خطا در ذخیره‌سازی داده‌ها!');
      }
    });
  }

  closeModal(): void {
    const modalElement = document.getElementById('sessionModal');
    if (modalElement) {
      window.bootstrap.Modal.getInstance(modalElement)?.hide();
    }
  }

  askForDelete(id: string | number): void {
    this.swalService.fireSwal('آیا از حذف این جلسه اطمینان دارید؟').then((t: { value: any; dismiss?: any }) => {
      if (t.value === true) {
        this.baseDataService.delete(id).subscribe({
          next: () => {
            this.getRecords();
          },
          error: (err) => {
            console.error('Error deleting record:', err);
            this.swalService.fireSwal('خطا در حذف داده!');
          }
        });
      } else {
        this.swalService.dismissSwal(t);
      }
    });
  }
}