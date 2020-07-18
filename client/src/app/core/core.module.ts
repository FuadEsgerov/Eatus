import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { SectionHeaderComponent } from './section-header/section-header.component';
import{BreadcrumbModule} from 'xng-breadcrumb';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [NavBarComponent, SectionHeaderComponent],
  imports: [
    CommonModule,
    RouterModule,
    BreadcrumbModule,
    SharedModule,
  ],
  exports:[NavBarComponent,
    SectionHeaderComponent
  ]
})
export class CoreModule { }
