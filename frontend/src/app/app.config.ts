import { provideHttpClient, HTTP_INTERCEPTORS, withInterceptorsFromDi } from '@angular/common/http';
import { LoaderInterceptor } from './core/interceptors/loader.interceptor.service';
import { SecurityInterceptor } from './core/interceptors/security.interceptor.service';
import { ValidationInterceptor } from './core/interceptors/validation.interceptor.service';
import { provideRouter, RouterModule } from '@angular/router';
import { routes } from './app.routes';
import { ApplicationConfig, provideZonelessChangeDetection } from '@angular/core';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { ExceptionInterceptor } from './core/interceptors/exception.interceptor.service';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

export const appConfig: ApplicationConfig = {
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(
      withInterceptorsFromDi()
    ),
    provideZonelessChangeDetection(),
    provideRouter(routes),
    // provideOAuthClient(),
    { provide: LocationStrategy, useClass: HashLocationStrategy },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ValidationInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ExceptionInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: SecurityInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: LoaderInterceptor,
      multi: true
    },
  ]
};


