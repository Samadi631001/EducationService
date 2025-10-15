import { Component, OnInit } from '@angular/core';
import {
  ApexNonAxisChartSeries,
  ApexChart,
  ApexResponsive,
  ApexLegend,
  ApexTooltip,
  ApexDataLabels,
  ApexPlotOptions,
  ApexFill,
  NgApexchartsModule
} from 'ng-apexcharts';
declare var $: any;

@Component({
  selector: 'app-dashboard',
  standalone: true,
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
  imports: [
    RouterLink, NgFor, FormsModule, NgApexchartsModule, NgIf, ChartAutoResizeDirective
  ]
})
export class DashboardComponent   {
    /**
     *
     */
    constructor() {
      console.log("وارد شدیم");      
    }
}

type ApexChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  labels: string[];
  responsive: ApexResponsive[];
  legend: ApexLegend;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  fill: ApexFill;
  colors: string[];
};

import { Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { BreadcrumbService } from '../../services/framework-services/breadcrumb.service';
import { NgFor, NgIf } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ChartAutoResizeDirective } from '../../core/directives/chart-autoresize.directive';
import { end } from '@popperjs/core';

@Pipe({ name: 'safe' })
export class SafePipe implements PipeTransform {
  constructor(private domSanitizer: DomSanitizer, private readonly breadCrumbService: BreadcrumbService) {
    breadCrumbService.setTitle("داشبورد");
  }
  transform(url: string) {
    return this.domSanitizer.bypassSecurityTrustResourceUrl(url);
  }

}
