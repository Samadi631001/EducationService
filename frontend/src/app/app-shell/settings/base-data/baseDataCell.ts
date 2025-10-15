import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';

@Component({
  selector: 'app-base-data-cell-actions',
  template: `
    <div class="d-flex justify-content-center gap-2">
      <button class="btn btn-sm btn-primary" (click)="onEdit()">ویرایش</button>
      <button class="btn btn-sm btn-danger" (click)="onDelete()">حذف</button>
    </div>
  `
})
export class BaseDataCellActionsComponent implements ICellRendererAngularComp {
  params: any;

  agInit(params: any): void {
    this.params = params;
  }

  refresh(params: any): boolean {
    this.params = params;
    return true;
  }

  onEdit() {
    if (this.params?.onEdit) {
      this.params.onEdit(this.params.data);
    }
  }

  onDelete() {
    if (this.params?.onDelete) {
      this.params.onDelete(this.params.data);
    }
  }
}
