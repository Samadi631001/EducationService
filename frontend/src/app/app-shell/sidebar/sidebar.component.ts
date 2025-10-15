import { AfterContentInit, AfterViewInit, Component, HostListener, NgZone, OnInit } from '@angular/core'
import { Route, Router, RouterLink, RouterLinkActive } from '@angular/router';
import { LocalStorageService } from '../../services/framework-services/local.storage.service';
import { IsDeletage, ISSP, Main_USER_ID, PERMISSIONS_NAME, POSITION_ID, POSITION_NAME, USER_CLASSIFICATION_LEVEL_ID_NAME, USER_COMPANY_ID_NAME, USER_ID_NAME, USER_ORGANIZATION_CHART_ID_NAME } from '../../core/types/configuration';
import { NgClass, NgFor, NgIf } from '@angular/common';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';
import { CodeFlowService, getClientSettings } from '../../services/framework-services/code-flow.service';
import { environment } from '../../../environments/environment';
import { HasPermissionDirective } from '../../core/directives/has-permission.directive';
import { PermissionService } from '../../services/permission.service';
import { SidebarService } from '../../services/framework-services/sidebar.service';
import { DelegationService } from '../../services/delegation.service';

declare var $: any

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  standalone: true,
  imports: [RouterLink, RouterLinkActive, NgFor, NgClass, NgIf, FormsModule, HasPermissionDirective],
  styleUrls: ['./sidebar.component.css'],

})
export class SidebarComponent implements OnInit, AfterContentInit {
  authState$: any;
  isMenuCollapsed: boolean = false;
  isSettingsOpen: boolean = false;
  position: any;
  selectedDelegation: any;
  isDelegate: any;
  fileManagementUrl: any;
  constructor(private readonly router: Router, private readonly delegationService: DelegationService,
    private readonly sidebarService: SidebarService,
    private readonly localStorageService: LocalStorageService,
    private readonly userService: UserService,
    private readonly codeFlowService: CodeFlowService,
    private readonly permissionService: PermissionService,
    private readonly passwordFlowService: CodeFlowService,
    private readonly zone: NgZone) { }
  toggleSidebar(): void {
    this.isMenuCollapsed = !this.isMenuCollapsed;
    //this.sidebarService.toggleSidebar();
    const sidebarImage = document.querySelector('.sidebar-image') as HTMLElement;
    if (sidebarImage) {
      if (this.isMenuCollapsed) {
        sidebarImage.style.width = '70px';
        sidebarImage.style.height = '70px';
      } else {
        sidebarImage.style.width = '90px';
        sidebarImage.style.height = '90px';
      }
    }
  }


  toggleSettings(): void {
    this.isSettingsOpen = !this.isSettingsOpen;
  }
  switchAccount(item: any) {
    this.selectedDelegation = item.positionGuid;
    this.localStorageService.setItem(USER_ID_NAME, item.userGuid);
    this.localStorageService.setItem(POSITION_ID, item.positionGuid);
    this.getPermissions(item.positionGuid, item.id, item.isDelegate);
    this.localStorageService.setItem(IsDeletage, item.isDelegate.toString());
    this.localStorageService.setItem(ISSP, item.isSuperAdmin.toString());
    this.router.navigateByUrl('/dashboard');
    //location.reload();
  }
  getPermissions(positionGuid: string, delegationId: any, isDelegate: boolean) {
    if (isDelegate) {
      const request = {
        delegationId: delegationId,
        clientId: getClientSettings().client_id
      };
      this.delegationService.getDelegationPermissions(request).subscribe({
        next: permissions => {
          this.localStorageService.removeItem(PERMISSIONS_NAME);
          this.localStorageService.setItem(PERMISSIONS_NAME, permissions);
          this.router.navigateByUrl('/dashboard');
          location.reload();
        },
        error: () => this.codeFlowService.logout(),
      });
    }
    else {

      this.permissionService
        .getPositionPermissions(positionGuid)
        .subscribe({
          next: permissions => {
            this.localStorageService.removeItem(PERMISSIONS_NAME);
            this.localStorageService.setItem(PERMISSIONS_NAME, permissions)
            this.router.navigateByUrl('/dashboard');
            location.reload();

          },
          error: () => this.codeFlowService.logout(),
        })
    }

  }
  delegations: any[] = [];
  information = {
    fullname: '',
    companyTitle: '',
    organizationChartTitle: '',
    classificationLevel: '',
    needChangePassword: false,
    companyGuid: '',
    organizationChartGuid: '',
    userName: ''
  }



  ngOnInit(): void {
    // const authState= this.secureStateService.getAuthState();
    // this.position = authState.positionName;
    // const positionGuid = authState.positionId ?? '';
    // this.selectedDelegation = positionGuid;
    // this.isDelegate = this.localStorageService.getItem(IsDeletage) === 'true' ? true : false;
    // this.userInformation();
    // this.isMenuCollapsed = this.localStorageService.getItem('templateCustomizer-vertical-menu-template--LayoutCollapsed') === 'true' ? true : false;
  }

  loadDelegations(userId: string) {
    // const auth = this.secureStateService.getAuthState();
    // const request = {
    //   userGuid: userId,
    //   positionGuid: auth.positionId ?? '',
    // };
    // this.delegationService.getActiveDelegationsForDelegatee(request).subscribe((delegations: any) => {
    //   this.delegations = delegations;
    //   if (Array.isArray(this.delegations) && this.delegations.length === 1) {
    //     this.delegations = [];
    //   }
    // });
  }
  navigateTo(url: string) {
    this.router.navigateByUrl(url)
  }

  ngAfterContentInit(): void {
  }

  userInformation() {
    // const auth = this.secureStateService.getAuthState();
    // this.userService
    //   .getUserInformation(auth.mainUserId)
    //   .subscribe({
    //     next: result => {
    //       this.loadDelegations(auth.mainUserId??'');
    //       this.information = result;
    //       this.fileManagementUrl = environment.fileManagementEndpoint + '/photo/' + result.userName + '    .jpg';
    //       this.localStorageService.setItem(USER_COMPANY_ID_NAME, result.companyGuid)
    //       this.localStorageService.setItem(USER_ORGANIZATION_CHART_ID_NAME, result.organizationChartGuid)
    //       this.localStorageService.setItem(USER_CLASSIFICATION_LEVEL_ID_NAME, result.classificationLevelGuid)
    //     },
    //     complete: () => { }
    //   })
  }

}

