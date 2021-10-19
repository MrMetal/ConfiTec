import { Component, OnInit } from '@angular/core';
import { Usuarios } from '../models/usuario';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {
  constructor(private usuarioService: UsuarioService) { }
  public usuarios: Usuarios[];

  ngOnInit() {
    this.usuarioService.obterUsuarios().subscribe( usuarios => { this.usuarios = usuarios });
  }
}
