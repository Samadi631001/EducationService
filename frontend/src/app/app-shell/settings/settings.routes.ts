import { Routes } from "@angular/router";
import { BaseDataComponent } from "./base-data/base-data";
import { CourseGroup } from "./course-group/course-group";
import { TrainingCorses } from "./traning-corses/training-corses";

export const settingRoutes: Routes = [
  { path: 'baseData/:type', component: BaseDataComponent },
  { path: 'groups', component: CourseGroup },
  { path: 'trainingCourse', component: TrainingCorses }
];
