import { UsuarioService } from 'src/app/pages/usuarios/usuario.service';
import { Usuarios } from './../models/usuario';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-remover',
  templateUrl: './remover.component.html'
})
export class RemoverComponent {

  usuario: Usuarios;
  errors: any[] = [];
  alertState = false;

  constructor(
    private usuarioService: UsuarioService,
    private route: ActivatedRoute,
    private router: Router,
    private toastr: ToastrService) {
    this.usuario = this.route.snapshot.data['usuario'];
  }

  removerUsuario() {
    this.usuarioService.removerUsuario(this.usuario.id)
      .subscribe(
        usu => { this.sucessoExclusao(usu) },
        error => { this.falha(error) }
      );
  }

  public sucessoExclusao(evento: any) {
    this.router.navigate(['/lista']);
  }

  falha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}
