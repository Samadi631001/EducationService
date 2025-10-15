import { Component, ChangeDetectorRef, OnInit } from '@angular/core';
import { BreadcrumbService } from '../../services/framework-services/breadcrumb.service';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-breadcrumb',
  templateUrl: './breadcrumb.component.html',
  standalone: true,
  imports:[NgIf,NgFor,RouterLink,NgClass]
})
export class BreadcrumbComponent implements OnInit {

  title: string = '';
  classificationLevel: string = 'عادی';
  breadcrumb: { label: string; routerLink: string; }[] = [];

  constructor(readonly breadcrumbService: BreadcrumbService) { }

  ngOnInit(): void {
    this.breadcrumbService._titleBS.subscribe(title => {
      this.title = title;
    });

    this.breadcrumbService._classificationLevelBS.subscribe(level => {
      this.classificationLevel = level;
    });

    this.breadcrumbService._breadcrumbBS.subscribe(breadcrumb => {
      this.breadcrumb = breadcrumb;
    });
  }
}