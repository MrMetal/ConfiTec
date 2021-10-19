import { RemoverComponent } from './../../pages/usuarios/remover/remover.component';
import { DetalheComponent } from './../../pages/usuarios/detalhe/detalhe.component';
import { EditarComponent } from './../../pages/usuarios/editar/editar.component';
import { NovoComponent } from './../../pages/usuarios/novo/novo.component';
import { ListaComponent } from './../../pages/usuarios/lista/lista.component';
import { Routes } from '@angular/router';
import { UsuarioResolve } from 'src/app/pages/usuarios/usuario.resolve';

export const AdminLayoutRoutes: Routes = [
    { path: 'lista', component: ListaComponent },
    { path: 'novo', component: NovoComponent },
    { path: 'editar/:id', component: EditarComponent, resolve: { usuario: UsuarioResolve } },
    { path: 'detalhe/:id', component: DetalheComponent, resolve: { usuario: UsuarioResolve } },
    { path: 'remover/:id', component: RemoverComponent, resolve: { usuario: UsuarioResolve }},
];
