import { UsuarioService } from 'src/app/pages/usuarios/usuario.service';
import { Usuarios } from './../models/usuario';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhe',
  templateUrl: './detalhe.component.html'
})
export class DetalheComponent  {

  usuario: Usuarios;

  constructor(
    private route: ActivatedRoute,
    ) { 
      this.usuario = this.route.snapshot.data['usuario'];
    }

  

}
