import { Component, OnInit, AfterViewInit, ViewChild, AfterContentInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { environment } from '../../../environments/environment';
import { CodeFlowService } from '../../services/framework-services/code-flow.service';
import { USER_COMPANY_ID_NAME, USER_ORGANIZATION_CHART_ID_NAME, USER_CLASSIFICATION_LEVEL_ID_NAME, USER_ID_NAME, IsDeletage } from '../../core/types/configuration';
import { LocalStorageService } from '../../services/framework-services/local.storage.service';
import { PasswordFlowService } from '../../services/framework-services/password-flow.service';
import { UserService } from '../../services/user.service';
import { NgFor, NgIf } from '@angular/common';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { SidebarService } from '../../services/framework-services/sidebar.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ["./header.style.css"],
  standalone: true,
  imports: [NgIf, NgbDropdownModule]
})
export class HeaderComponent implements OnInit {
  // isDeletage: boolean = false;
  // notifications = []
  // information = {
  //   fullname: '',
  //   companyTitle: '',
  //   organizationChartTitle: '',
  //   classificationLevel: '',
  //   needChangePassword: false,
  //   companyGuid: '',
  //   organizationChartGuid: '',
  //   userName: ''
  // }
  // delegations: any[] = [];
  // selectedDelegationId!: any;
  // passwordStrength = 0
  // tabItem = 1
  // form!: FormGroup<{ password: FormControl<string | null>; rePassword: FormControl<string | null>; currentPassword: FormControl<string | null>; }>
toggle(){
this.sidebarService.toggleSidebar();
}
  constructor(
    private readonly fb: FormBuilder,
    private readonly passwordFlowService: PasswordFlowService,
    private readonly codeFlowService: CodeFlowService,
    private sidebarService: SidebarService) {
  }

  // ngAfterContentInit(): void {
  //   this.userInformation()
  // }

  // ngOnInit(): void {
  //   this.form = this.fb.group({
  //     password: [''],
  //     rePassword: [''],
  //     currentPassword: [''],
  //   });
  //   this.isDeletage = this.localStorageService.getItem(IsDeletage) == 'true';

  // }
  // loadDelegations(userId: string) {
  //   this.delegationService.getActiveDelegationsForDelegatee(userId).subscribe((delegations: any) => {
  //     this.delegations = delegations;
  //   });
  // }
  // get password() {
  //   return this.form.get('password')?.value
  // }

  // userInformation() {
  //   const userGuid = this.localStorageService.getItem(USER_ID_NAME);
  //   this.userService
  //     .getUserInformation(userGuid)
  //     .subscribe({
  //       next: result => {
  //         this.information = result
  //         this.localStorageService.setItem(USER_COMPANY_ID_NAME, result.companyGuid)
  //         this.localStorageService.setItem(USER_ORGANIZATION_CHART_ID_NAME, result.organizationChartGuid)
  //         this.localStorageService.setItem(USER_CLASSIFICATION_LEVEL_ID_NAME, result.classificationLevelGuid)
  //       },
  //       complete: () => { }
  //     })
  // }


  logout() {
    if (environment.ssoAuthenticationFlow == 'code') {
      this.codeFlowService.logout()
    } else {
      this.passwordFlowService.logout()
    }
  }

  redirectToGrants() {
    window.location.href = `${environment.identityEndpoint}/grants`
  }

  currentDate: string = '';
  currentTime: string = '';
  currentDay: string = '';
  fullDateTime: string = '';

  ngOnInit() {
    this.updateDateTime();
    setInterval(() => this.updateDateTime(), 1000);
  }

  updateDateTime() {
    const now = new Date();
    const options: Intl.DateTimeFormatOptions = { weekday: 'long', year: 'numeric', month: 'long', day: 'numeric' };

    this.currentDate = now.toLocaleDateString('fa-IR');
    this.currentTime = now.toLocaleTimeString('fa-IR');
    this.currentDay = now.toLocaleDateString('fa-IR', { weekday: 'long' });
    this.fullDateTime = now.toLocaleString('fa-IR', options) + ' - ' + now.toLocaleTimeString('fa-IR');
  }
}
