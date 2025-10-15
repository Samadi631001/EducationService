import { inject } from "@angular/core";
import { environment } from "../../../environments/environment";
import { CodeFlowService } from "../../services/framework-services/code-flow.service";
import { PasswordFlowService } from "../../services/framework-services/password-flow.service";

export const authGuard = () => {
    const codeFlowService = inject(CodeFlowService);
    const passwordFlowService = inject(PasswordFlowService);
  
    if (environment.ssoAuthenticationFlow === 'code') {
      if (codeFlowService.isLoggedIn()) {
        return true;
      }
  
      codeFlowService.startAuthentication();
      return false;
    } else {
      if (passwordFlowService.isLoggedIn()) {
        return true;
      }
  
      passwordFlowService.logout();
      return false;
    }
  }
  