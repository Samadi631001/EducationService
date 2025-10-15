import { inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from '../../../environments/environment';
import { BreadcrumbService } from './breadcrumb.service';
import { LocalStorageService } from './local.storage.service';
import { ACCESS_TOKEN_NAME, ROLE_TOKEN_NAME, USER_ID_NAME, PERMISSIONS_NAME, SETTINGS_NAME, DATABASAE_NAME, USER_COMPANY_ID_NAME, USER_ORGANIZATION_CHART_ID_NAME, USER_CURRENT_ACTIVE_SESSION_NAME, POSITION_ID, POSITION_NAME, IsDeletage, Main_USER_ID, ISSP } from '../../core/types/configuration';
import { User, UserManager, UserManagerSettings } from 'oidc-client';
import { UserService } from '../user.service';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class CodeFlowService {
    storeToken(access_token: any) {
      throw new Error('Method not implemented.');
    }
    private manager = new UserManager(getClientSettings());
    public user!: User | null;

    constructor(
        private readonly router: Router,
        private readonly userService: UserService,
        private readonly breadcrumbService: BreadcrumbService,
        private readonly localStorageService: LocalStorageService,
        private readonly http: HttpClient) {

        this.manager
            .getUser()
            .then(user => {
                this.user = user;
            })
    }

    loginWithPortalCredentials(username: string, key: string) {
        const body = new HttpParams()
            .set('grant_type', 'portal_login')
            .set('client_id', 'MeetManage')
            .set('client_secret', 'sgvzgd#$5354erk65&%')
            .set('username', username)
            .set('key', key);

        return this.http.post<any>(`${environment.identityEndpoint}/connect/token`, body.toString(), {
            headers: new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' })
        });
    }

    isLoggedIn(): boolean {
        return this.localStorageService.exists(ACCESS_TOKEN_NAME)
    }

    getClaims(): any {
        return this.user?.profile;
    }

    getAuthorizationHeaderValue(): string {
        return `${this.user?.token_type} ${this.user?.access_token}`;
    }

    startAuthentication(): Promise<void> {
        return this.manager.signinRedirect({ isCheckAuthority: true });
    }

    async completeAuthentication(): Promise<void> {
        //this.user = await this.manager.getUser();
        return this.manager.signinRedirectCallback().then(user => {
            this.user = user;
        });
    }

    logout() {
        if (this.isLoggedIn()) {
            this.localStorageService.removeItem(ACCESS_TOKEN_NAME);
            this.localStorageService.removeItem(ROLE_TOKEN_NAME);
            this.localStorageService.removeItem(USER_ID_NAME);
            this.localStorageService.removeItem(POSITION_ID);
            this.localStorageService.removeItem(POSITION_NAME);
            this.localStorageService.removeItem(IsDeletage);
            this.localStorageService.removeItem(PERMISSIONS_NAME);
            this.localStorageService.removeItem(SETTINGS_NAME);
            this.localStorageService.removeItem(DATABASAE_NAME);
            this.localStorageService.removeItem(USER_COMPANY_ID_NAME);
            this.localStorageService.removeItem(USER_ORGANIZATION_CHART_ID_NAME);
            this.localStorageService.removeItem(USER_CURRENT_ACTIVE_SESSION_NAME);
            this.localStorageService.removeItem(Main_USER_ID);
            this.localStorageService.removeItem(ISSP);
            this.breadcrumbService.reset();
            this.manager.signoutRedirect();
        } else {
            this.startAuthentication();
        }
    }

    getToken() {
        return this.localStorageService.getItem(ACCESS_TOKEN_NAME);
    }
}

export function getClientSettings(): UserManagerSettings {
    return {
        authority: environment.identityEndpoint,
        client_id: 'EducationCode',
        client_secret: 'sgvzgd#$5354erk65&%',
        redirect_uri: `${environment.selfEndpoint}/#/challenge`,
        post_logout_redirect_uri: environment.selfEndpoint,
        response_type: "code",
        scope: "openid profile UserManagementApi FileManagementApi EducationApi",
        filterProtocolClaims: true,
        loadUserInfo: true
    };
}