import { BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class BreadcrumbService {
 
  title!: string;
  _titleBS = new BehaviorSubject('')

  classificationLevel!: string;
  _classificationLevelBS = new BehaviorSubject('')

  breadcrumb: any;
  _breadcrumbBS = new BehaviorSubject<{ label: string; routerLink: string; }[]>([]);

  constructor() {
    this._breadcrumbBS.next(this.breadcrumb);
  }

  setTitle(title: string) {
    this.title = title;
    this._titleBS.next(title);
  }
  setItems(arg0: { label: string; routerLink: string; }[]) {
    this.breadcrumb = arg0;
    this._breadcrumbBS.next(arg0);
  }
  emptyTitle() {
    this.title = '';
    this._titleBS.next(this.title);
  }

  setClassificationLevel(result: any): void {
    this.classificationLevel = result;
    this._classificationLevelBS.next(result);
  }

  emptyClassificationLevel(): void {
    this.classificationLevel = '';
    this._classificationLevelBS.next(this.classificationLevel);
  }

  setBreadcrumb(data: never[]) {
    this.breadcrumb = data;
    this._breadcrumbBS.next(data);
  }

  emptyBreadcrumb() {
    this.breadcrumb = [];
    this._breadcrumbBS.next(this.breadcrumb);
  }

  reset() {
    this.emptyTitle()
    this.emptyBreadcrumb()
    this.emptyClassificationLevel()
  }
}