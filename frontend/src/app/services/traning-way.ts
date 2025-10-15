import { Injectable } from '@angular/core';
import { ServiceBase } from './framework-services/service.base';

@Injectable({
  providedIn: 'root'
})
export class TraningWayService extends ServiceBase {
  constructor() {
    super("TrainingWay");
  }
}
