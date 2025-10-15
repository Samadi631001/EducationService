import { AfterViewInit, Component, Renderer2 } from '@angular/core';
import { HeaderComponent } from "./header/header.component";
import { BreadcrumbComponent } from "./breadcrumb/breadcrumb.component";
import { RouterOutlet } from '@angular/router';
import { SwalService } from '../services/framework-services/swal.service';
import { FooterComponent } from "./footer/footer.component";
import { SidebarComponent } from './sidebar/sidebar.component';

@Component({
  selector: 'app-app-shell',
  imports: [SidebarComponent, HeaderComponent, BreadcrumbComponent, RouterOutlet, FooterComponent],
  templateUrl: './app-shell.component.html',
  styleUrl: './app-shell.component.css',
  standalone: true
})
export class AppShellComponent {
  // @HostListener('window:beforeunload', ['$event'])
  // handleBeforeUnload(event: BeforeUnloadEvent) {
  //   // مثلا خروج از سیستم یا پاک کردن session
  //   console.log('در حال خروج از برنامه');

  //   // اگر می‌خواهی از کاربر تایید بگیری:
  //   event.preventDefault();
  //   event.returnValue = ''; // برای نمایش دیالوگ پیش‌فرض مرورگر
  // }
  // constructor(
  //   private renderer: Renderer2) { }
  // ngAfterViewInit() {
  //   this.loadScripts([
  //     'js/main.js'
  //   ]);
  // }

  // private loadScripts(scripts: string[]): void {
  //   scripts.forEach(src => {
  //     const script = this.renderer.createElement('script');
  //     script.src = src;
  //     script.type = 'text/javascript';
  //     script.defer = true;
  //     this.renderer.appendChild(document.body, script);
  //   });
  }
