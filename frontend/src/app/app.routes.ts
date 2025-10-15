import { Routes } from '@angular/router';
import { AppShellComponent } from './app-shell/app-shell.component';
import { DashboardComponent } from './app-shell/dashboard/dashboard.component';
import { clientAccessGuard } from './core/guards/client.access.guard.service';
import { sessionGuard } from './core/guards/session.guard.service';
import { ChallengeComponent } from './authentication/challenge/challange.component';
import { authGuard } from './core/guards/auth.guard.service';
// export const routes: Routes = [
//   {
//     path: '',
//     component: AppShellComponent,
//     canActivate: [authGuard, sessionGuard, clientAccessGuard],
//     runGuardsAndResolvers: 'always',
//     children: [
//       { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
//       { path: 'dashboard', component: DashboardComponent },
//       {
//         path: 'meetings',
//         loadChildren: () =>
//           import('./app-shell/meetings/meetings.routes').then(m => m.meetingsRoutes)
//       },
//       {
//         path: 'resolutions',
//         loadChildren: () =>
//           import('./app-shell/resolutions/resolutions.routes').then(m => m.resolutionsRoutes)
//       },
//       {
//         path: 'delegation',
//         loadChildren: () =>
//           import('./app-shell/delegation/delegations.routes').then(m => m.delegationRouts)
//       },
//       { path: 'calendar', component: CalendarComponent },
//       { path: 'search', component: SearchComponent },
//     ]
//   },
//   {
//     path: 'challenge',
//     component: ChallengeComponent
//   },
//   {
//     path: '**',
//     redirectTo: 'dashboard',
//     pathMatch: 'full'
//   },
// ];
// routes configuration
// export const routes: Routes = [
//   {
//     path: '',
//     component: AppShellComponent,
//     canActivate: [authGuard, sessionGuard, clientAccessGuard, challengeGuard], // اضافه کردن challengeGuard
//     //resolve: { challengeData: challengeResolver }, // یا استفاده از resolver
//     runGuardsAndResolvers: 'always',
//     children: [
//       { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
//       {
//         path: 'dashboard',
//         component: DashboardComponent,
//         //resolve: { challengeData: challengeResolver } // اضافه کردن resolver به dashboard
//       },
//       {
//         path: 'meetings',
//         loadChildren: () =>
//           import('./app-shell/meetings/meetings.routes').then(m => m.meetingsRoutes)
//       },
//       {
//         path: 'resolutions',
//         loadChildren: () =>
//           import('./app-shell/resolutions/resolutions.routes').then(m => m.resolutionsRoutes)
//       },
//       {
//         path: 'delegation',
//         loadChildren: () =>
//           import('./app-shell/delegation/delegations.routes').then(m => m.delegationRouts)
//       },
//       {path:'calendar', component: CalendarComponent},
//       { path: 'search', component: SearchComponent },
//     ]
//   },
//   {
//     path: 'challenge',
//     component: ChallengeComponent
//   },
//   {
//     path: '**',
//     redirectTo: 'dashboard',
//     pathMatch: 'full'
//   },
// ];

// export const routes: Routes = [{
//     path: '', component: AppShell

// },];


export const routes: Routes = [
  {
    path: '',
    component: AppShellComponent,
    canActivate: [authGuard, sessionGuard, clientAccessGuard],
    runGuardsAndResolvers: 'always',
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      {
        path: 'setting',
        loadChildren: () =>
          import('./app-shell/settings/settings.routes').then(x=>x.settingRoutes)
      },

      //   {
      //     path: 'meetings',
      //     loadChildren: () =>
      //       import('./app-shell/meetings/meetings.routes').then(m => m.meetingsRoutes)
      //   },
      //   {
      //     path: 'resolutions',
      //     loadChildren: () =>
      //       import('./app-shell/resolutions/resolutions.routes').then(m => m.resolutionsRoutes)
      //   },
      //   {
      //     path: 'delegation',
      //     loadChildren: () =>
      //       import('./app-shell/delegation/delegations.routes').then(m => m.delegationRouts)
      //   },
      //   { path: 'calendar', component: CalendarComponent },
      //   { path: 'search', component: SearchComponent },
    ]
  },
    {
      path: 'challenge',
      component: ChallengeComponent
    },
  {
    path: '**',
    redirectTo: 'dashboard',
    pathMatch: 'full'
  },
];