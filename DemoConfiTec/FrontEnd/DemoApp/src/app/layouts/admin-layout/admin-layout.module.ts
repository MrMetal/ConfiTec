import { UsuarioResolve } from './../../pages/usuarios/usuario.resolve';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { ClipboardModule } from 'ngx-clipboard';

import { AdminLayoutRoutes } from './admin-layout.routing';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UsuarioService } from 'src/app/pages/usuarios/usuario.service';


@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(AdminLayoutRoutes),
    FormsModule,
    HttpClientModule,
    NgbModule,
    ClipboardModule,
   
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
    HttpClientModule
    
  ],
  declarations: [
  ],
  providers: [
    UsuarioService,
    UsuarioResolve
  ],
})

export class AdminLayoutModule {}
