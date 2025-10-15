import { Component, HostListener, OnDestroy } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
//   ngOnDestroy(): void {
//     alert('Are you sure you want to leave this page? Any unsaved changes will be lost.');
// }
  // @HostListener('window:beforeunload', ['$event'])
  // handleBeforeUnload(event: BeforeUnloadEvent) {
  //   // عملیات خروج یا پاکسازی
  //   alert('Are you sure you want to leave this page? Any unsaved changes will be lost.');
  //   // اگر نیاز به هشدار هست:
  //   event.preventDefault();
  //   event.returnValue = '';
  // }
}
