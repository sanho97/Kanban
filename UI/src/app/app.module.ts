import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import {
    DxPopupModule,
    DxButtonModule,
    DxTemplateModule,
    DxValidationGroupModule,
    DxTextBoxModule,
    DxDateBoxModule, DxPopoverModule, DxTextAreaModule
} from 'devextreme-angular';
import { DxBoxModule } from 'devextreme-angular';
import { DxCheckBoxModule,
  DxSelectBoxModule,
  DxNumberBoxModule,
  DxFormModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import {DxScrollViewModule, DxSortableModule} from 'devextreme-angular';
import {Service} from './app.service';
import { TaskComponent } from './task/task.component';
import {TaskService} from './task/task.service';

@NgModule({
  declarations: [
    AppComponent,
    TaskComponent,
  ],
    imports: [
        BrowserModule,
        DxScrollViewModule,
        DxSortableModule,
        DxPopupModule,
        DxButtonModule,
        DxTemplateModule,
        DxBoxModule,
        DxCheckBoxModule,
        DxSelectBoxModule,
        DxNumberBoxModule,
        DxFormModule,
        HttpClientModule,
        DxValidationGroupModule,
        DxTextBoxModule,
        DxDateBoxModule,
        DxPopoverModule,
        DxTextAreaModule,
    ],
  providers: [Service, TaskService],
  bootstrap: [AppComponent]
})
export class AppModule { }
