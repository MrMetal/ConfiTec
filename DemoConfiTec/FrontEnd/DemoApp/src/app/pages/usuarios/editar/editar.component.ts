import { Usuarios } from './../models/usuario';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioService } from '../usuario.service';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html'
})
export class EditarComponent implements OnInit {

  formulario: FormGroup;
  usuario: Usuarios;  
  alertState = false;
  submitted = false;  
  errors: any[] = [];

  constructor(private fb: FormBuilder,
    private usuarioService: UsuarioService,
    private router: Router,
    private route: ActivatedRoute,) { 
      this.usuario = this.route.snapshot.data['usuario'];
    }

  ngOnInit(): void {

    let data = this.dataNascimento();

    this.formulario = this.fb.group({
      nome:['',[Validators.required]],
      sobreNome: ['', [Validators.required]],
      dataNascimento: ['', [Validators.required, this.dateValidator]],
      email: ['', [Validators.required]],
      escolaridade: ['', [Validators.required]]
    });

    this.formulario.patchValue({
      id: this.usuario.id,
      nome:this.usuario.nome,
      sobreNome: this.usuario.sobreNome,
      dataNascimento: data,
      email: this.usuario.email,
      escolaridade: this.usuario.escolaridade
    })

  }  

  dataNascimento()
  {
    let newDate = new Date(this.usuario.dataNascimento);
    return newDate.toJSON().split('T')[0];
  }

  editarUsuario()
  {
    this.usuario = Object.assign({}, this.usuario, this.formulario.value);  

    this.submitted = true;
    this.alertState = false;

    this.usuarioService.editarUsuario(this.usuario)
      .subscribe(
        sucesso => { this.processarSucesso(sucesso) },
        falha => { this.processarFalha(falha) }
      );
  }

  processarSucesso(response: any) {
    this.formulario.reset();
    this.errors = [];

    this.router.navigate(['/lista-usuario']);  
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
  }

  dateValidator(c: AbstractControl): { [key: string]: boolean } {
    let value = c.value;
    if (value && typeof value === "string") {
      let match = value.match(/^([12]\d{3}-(0[1-9]|1[0-2])-(0[1-9]|[12]\d|3[01]))/);
      if (!match) {
        return { 'dateInvalid': true };
      } else if (match && match[0] !== value) {
        return { 'dateInvalid': true };
      }
    }
    return null;
  }

}
