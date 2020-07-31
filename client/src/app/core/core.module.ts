import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import {ToastrModule} from 'ngx-toastr';
import {BreadcrumbModule} from 'xng-breadcrumb';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { SharedModule } from '../shared/shared.module';
import { FooterComponent } from './footer/footer.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import{MatIconModule} from '@angular/material/icon'
import {MatSidenavModule} from '@angular/material/sidenav'
import {MatButtonModule} from '@angular/material/button'
import { HeaderComponent } from './header/header.component';
import {FlexLayoutModule} from '@angular/flex-layout'
import { MatListModule } from '@angular/material/list';
import { MatGridListModule } from '@angular/material/grid-list';
@NgModule({
  declarations: [ TestErrorComponent, NotFoundComponent, ServerErrorComponent, SectionHeaderComponent, FooterComponent, HeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    BreadcrumbModule,
    SharedModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    MatToolbarModule,
    MatIconModule,
    MatSidenavModule,
    MatButtonModule,
    FlexLayoutModule,
    MatListModule,
    MatGridListModule,

  ],
  exports:[
    SectionHeaderComponent,
    FooterComponent,
    HeaderComponent

  ]
})
export class CoreModule { }
