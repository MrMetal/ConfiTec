import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';

import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';
import { NovoComponent } from './pages/usuarios/novo/novo.component';
import { DetalheComponent } from './pages/usuarios/detalhe/detalhe.component';
import { EditarComponent } from './pages/usuarios/editar/editar.component';
import { RemoverComponent } from './pages/usuarios/remover/remover.component';
import { ListaComponent } from './pages/usuarios/lista/lista.component';
import { ToastrModule } from 'ngx-toastr';


@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpClientModule,
    ComponentsModule,
    NgbModule,
    RouterModule,
    AppRoutingModule,

    
   
    ReactiveFormsModule,
    FormsModule,
    NgbModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    NovoComponent,
    DetalheComponent,
    EditarComponent,
    RemoverComponent,
    ListaComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
