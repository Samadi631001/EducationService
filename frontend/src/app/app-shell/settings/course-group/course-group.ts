import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CourseGroupService } from '../../../services/course-group.service';
import { data } from 'jquery';
import { CourseGroupCellComponent } from './course-groupCellOptions';
import { CourseGroupDto } from '../../../core/models/CourseGroupDto';
import { SwalService } from '../../../services/framework-services/swal.service';
import { AgGridAngular } from "ag-grid-angular";
import { ComboBase } from '../../../shared/combo-base';
import { AgGridBaseComponent } from '../../../shared/ag-grid-base/ag-grid-base';
import { LabelButtonComponent } from '../../../shared/custom-buttons/label-button';
import { CustomSelectComponent } from '../../../shared/custom-controls/custom-select';

@Component({
  selector: 'app-course-group',
  imports: [LabelButtonComponent, AgGridAngular, ReactiveFormsModule, CustomSelectComponent],
  templateUrl: './course-group.html',
  styleUrl: './course-group.css'
})
export class CourseGroup extends AgGridBaseComponent implements OnInit {
  private readonly courseGroupService = inject(CourseGroupService);
  private readonly fb = inject(FormBuilder);
  private readonly swalService = inject(SwalService);
  groups: ComboBase[] = [];
  form!: FormGroup;
  records: any;
  isEditMode = false;
  constructor() {
    super();
    this.form = this.fb.group({
      id: [0],
      title: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(100)]],
      comment: ['', Validators.maxLength(1000)],
      parent: [null]
    });

  }
  override ngOnInit(): void {

    this.getRecords();
    this.setupGridColumns();
  }

  private loadGroups(groupId?:number|null) {
    this.courseGroupService.getForCombo<ComboBase[]>().subscribe(data => {

      this.groups = data.filter(x=>x.id!=groupId);
    })
  }

  override onGridReady(params: any): void {
    this.gridApi = params.api;
    this.getRecords();
  }
  private setupGridColumns(): void {
    this.gridOptions().columnDefs = [
      {
        headerName: 'عملیات',
        cellRenderer: CourseGroupCellComponent,
        cellRendererParams: {
          onEdit: (rowData: CourseGroupDto) => this.openModal(rowData),
          onDelete: (rowData: CourseGroupDto) => this.askForDelete(rowData.id)
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
      { field: 'group', headerName: 'گزوه والد' }
      // { field: 'created', headerName: 'تاریخ ایجاد' },
    ];
  }

  getRecords() {
    this.courseGroupService.getList().subscribe((data: any) => {
      this.records = data;
        if (this.gridApi) {
          this.gridApi().setGridOption('rowData', this.records); // جایگزین setRowData
        }
    });
  }



  openModal(editData?: CourseGroupDto): void {
    if (editData) {
      this.isEditMode = true;
      // this.session = { title: editData.title, comment: editData.comment };
      this.courseGroupService.getForEdit<CourseGroupDto>(editData.id).subscribe({
        next: (data) => {
          this.form.patchValue({
            id: data.id,
            title: data.title,
            comment: data.comment
          });
          this.loadGroups(data.id);

        }
      });
    } else {
      this.isEditMode = false;
      // this.session = { title: '', comment: '' };
      this.form.reset({ id: 0 });
          this.loadGroups();
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
      ? this.courseGroupService.edit(model)
      : this.courseGroupService.create(model);

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
        this.courseGroupService.delete(id).subscribe({
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
