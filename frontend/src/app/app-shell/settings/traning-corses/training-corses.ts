import { ChangeDetectorRef, Component, inject, OnInit } from '@angular/core';
import { AgGridAngular } from "ag-grid-angular";
import { AgGridBaseComponent } from '../../../shared/ag-grid-base/ag-grid-base';
import { ComboBase } from '../../../shared/combo-base';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SwalService } from '../../../services/framework-services/swal.service';
import { TraningCourseService } from '../../../services/traning-course.service ';
import { TraningCourceCellComponent } from './traning-courseCellOptions';
import { TraningCourseListDto } from '../../../core/models/TraningCourseListDto';
import { LabelButtonComponent } from '../../../shared/custom-buttons/label-button';
import { CustomSelectComponent } from '../../../shared/custom-controls/custom-select';
import { CustomInputComponent } from "../../../shared/custom-controls/custom-input";
import { BaseDataService } from '../../../services/basedata-service';

@Component({
  selector: 'app-training-corses',
  imports: [AgGridAngular, LabelButtonComponent, ReactiveFormsModule, CustomSelectComponent, CustomInputComponent],
  templateUrl: './traning-corses.html',
  styleUrl: './training-course.css'
})


export class TrainingCorses extends AgGridBaseComponent implements OnInit {
  private readonly traningCourseService = inject(TraningCourseService);
  private readonly baseDataService = inject(BaseDataService);
  private readonly fb = inject(FormBuilder);
  private readonly swalService = inject(SwalService);
  groups: ComboBase[] = [];
  form!: FormGroup;
  records: any[] = [];
  isEditMode = false;
  selectedRecordId: string | null = null;
  activeTab = 'definitions';
  courseLayout: ComboBase[] = [];


  constructor(private cdr: ChangeDetectorRef) {
    super();
    this.form = this.fb.group({
      guid: [''],
      title: ['', [Validators.required, Validators.maxLength(200)]],
      number: ['', [Validators.required, Validators.maxLength(50)]],
      visionaryPeriod: ['', [Validators.maxLength(5)]],
      practicalPeriod: ['', [Validators.maxLength(5)]],
      titleEnglish: ['', [Validators.maxLength(200)]],
      courseTypeId: [],//نوع
      trainingWayId: [],
      categoryId: [],
      courseExamId: [],
      courseGroupId: [],
      courseLayoutId: [],
      compass: ['', [Validators.maxLength(50)]],
      exclusiveCode: ['', [Validators.maxLength(50)]],
      exclusivePermit: ['', [Validators.maxLength(50)]],
      isSpecial: [false],
      status: [],
      courseLevelId: [],
      isPortalContent: [false],
      branchId: [],
      isPublic: [false],
      strategies: [''],//اهداف راهبردی 
      performanceEvaluationParameter: [''],
      purpose: ['', [Validators.maxLength(4000)]],
      comment: ['', [Validators.maxLength(4000)]],
      daysToExpire: [],
      trainingScore: ['', Validators.maxLength(20)],
      trainingFieldId: [],
      daysToExtension: [],
      knowLedge: [],
      vision: [],
      skill: [],
      CreateReason: [''],
      tags: [''],
      benefit: [false],
      type: [''],
      level: [''],
      category: ['']
    });
  }
  //
  private loadCourseLayout(baseDataTypeId?: number | null) {
    this.baseDataService.getForCombo<ComboBase[]>().subscribe(data => {
      this.courseLayout = data.filter(x => x.id == baseDataTypeId);
    })
  }
  //
  getRecords() {
    this.traningCourseService.getList().subscribe({
      next: (data: any) => {
        console.log('Records received:', data);
        this.records = data;
        if (this.gridApi()) {
          this.gridApi().setGridOption('rowData', this.records); // جایگزین setRowData
        }
      },
      error: (err) => {
        console.error('Error loading records:', err);
        this.swalService.fireSwal('خطا در بارگذاری داده‌ها!');
      }
    });
  }
  //
  override ngOnInit(): void {
    this.getRecords();
    this.setupGridColumns();
  }
  //
  override onGridReady(params: any): void {
    this.gridApi = params.api;
    this.getRecords();
  }
  //
  private setupGridColumns(): void {
    this.gridOptions().columnDefs = [
      {
        headerName: 'عملیات',
        cellRenderer: TraningCourceCellComponent,
        cellRendererParams: {
          onEdit: (rowData: TraningCourseListDto) => this.openModal(rowData),
          onDelete: (rowData: TraningCourseListDto) => this.askForDelete(rowData.id)
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
      { field: 'number', headerName: 'کد' },
      { field: 'title', headerName: 'دوره' },
      { field: 'visionaryPeriod', headerName: 'مدت' },
      { field: 'type', headerName: 'نوع' },
      { field: 'category', headerName: 'ماهیت' },
      { field: 'level', headerName: 'سطح' }

      // { field: 'created', headerName: 'تاریخ ایجاد' },
    ];
  }
  //
  loadComboValue(): void {
    this.loadCourseLayout(1);
  }
  //
  closeModal(): void {
    const modalElement = document.getElementById('sessionModal');
    if (modalElement) {
      window.bootstrap.Modal.getInstance(modalElement)?.hide();
    }
  }
  //
  askForDelete(id: string | number): void {
    this.swalService.fireSwal('آیا از حذف این جلسه اطمینان دارید؟').then((t: { value: any; dismiss?: any }) => {
      if (t.value === true) {
        this.traningCourseService.delete(id).subscribe({
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
  //
  openModal(editData?: TraningCourseListDto): void {
    this.selectedRecordId = null;
    this.activeTab = 'definitions';
    if (editData) {
      this.isEditMode = true;
      //this.cdr.detectChanges();
      // this.session = { title: editData.title, comment: editData.comment };
      this.traningCourseService.getForEdit<TraningCourseListDto>(editData.guid).subscribe({
        next: (data) => {
          this.form.patchValue({
            id: data.id,
            guid: data.guid,
            title: data.title,
            number: data.number,
            visionaryPeriod: data.visionaryPeriod,
            practicalPeriod: data.practicalPeriod,
            titleEnglish: data.titleEnglish,
            courseTypeId: data.courseTypeId,
            trainingWayId: data.trainingWayId,
            categoryId: data.categoryId,
            courseExamId: data.courseExamId,
            courseGroupId: data.courseGroupId,
            courseLayoutId: data.courseLayoutId,
            compass: data.compass,
            exclusiveCode: data.exclusiveCode,
            exclusivePermit: data.exclusivePermit,
            isSpecial: data.isSpecial,
            status: data.status,
            courseLevelId: data.courseLevelId,
            isPortalContent: data.isPortalContent,
            branchId: data.branchId,
            isPublic: data.isPublic,
            strategies: data.strategies,
            performanceEvaluationParameter: data.performanceEvaluationParameter,
            purpose: data.purpose,
            comment: data.comment,
            daysToExpire: data.daysToExpire,
            trainingScore: data.trainingScore,
            trainingFieldId: data.trainingFieldId,
            daysToExtension: data.daysToExtension,
            knowLedge: data.knowLedge,
            vision: data.vision,
            skill: data.skill,
            CreateReason: data.CreateReason,
            tags: data.tags,
            benefit: data.benefit

          });
          this.loadComboValue();
          //this.loadGroups(data.id);

        }
      });
    } else {
      this.isEditMode = false;
      //this.cdr.detectChanges();
      // this.session = { title: '', comment: '' };
      this.form.reset({ id: 0 });
      this.loadComboValue();
      //this.loadGroups();
    }
    setTimeout(() => {
      this.isEditMode = !!editData;
    });
    const modalElement = document.getElementById('sessionModal');
    if (modalElement) {
      const modal = new window.bootstrap.Modal(modalElement);
      modal.show();
    }
  }
  //
  private loadGroups(groupId?: number | null) {
    this.traningCourseService.getForCombo<ComboBase[]>().subscribe(data => {

      this.groups = data.filter(x => x.id != groupId);
    })
  }
  //
  onSubmit(): void {
    // if (this.form.invalid) {
    //   this.swalService.fireSwal('لطفاً فرم را به درستی پر کنید!');
    //   return;
    // }

    const model = this.form.value;
    const operation = this.isEditMode
      ? this.traningCourseService.edit(model)
      : this.traningCourseService.create(model);

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
}
