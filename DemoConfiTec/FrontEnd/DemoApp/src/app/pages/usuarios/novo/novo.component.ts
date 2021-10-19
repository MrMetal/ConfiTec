import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Usuarios } from '../models/usuario';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-novo',
  templateUrl: './novo.component.html'
})
export class NovoComponent implements OnInit {
  
  formulario: FormGroup;
  submitted = false;
  usuario: Usuarios;
  errors: any[] = [];
  isClosed;


  constructor(private fb: FormBuilder, 
              private usuarioService: UsuarioService,
              private router: Router) { }

  ngOnInit(): void {

    this.formulario = this.fb.group({
      nome:['',[Validators.required]],
      sobreNome: ['', [Validators.required]],
      dataNascimento: ['', [Validators.required]],
      email: ['', [Validators.required]],
      escolaridade: ['', [Validators.required]]
    })
  }

  get f() { return this.formulario.controls; }

  adicionarUsuario()
  {
    this.submitted = true;
    this.usuario = Object.assign({}, this.usuario, this.formulario.value);

    this.usuarioService.novousuario(this.usuario)
      .subscribe(
        sucesso => { this.processarSucesso(sucesso) },
        falha => { this.processarFalha(falha) }
      );
  }

  processarSucesso(response: any) {
    this.submitted = false;
    this.formulario.reset();
    this.errors = [];
   
    this.router.navigate(['/lista-usuario']);    
    
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.isClosed = false;
  }

}
