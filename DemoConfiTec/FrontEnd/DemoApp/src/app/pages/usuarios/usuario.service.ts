import { Usuarios } from './models/usuario';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';

@Injectable()
export class UsuarioService extends BaseService{

constructor(private http: HttpClient) {
    super();
}
    protected UrlService: string = "https://localhost:5002/api/usuario/";

    obterUsuarios() : Observable<Usuarios[]> {
        return this.http.get<Usuarios[]>(this.UrlService);
    }

    obterPorId(id: number): Observable<Usuarios> {
        return this.http.get<Usuarios>(this.UrlService + id).pipe(catchError(super.serviceError));
    }

    novousuario(usuarios: Usuarios): Observable<Usuarios> {
        return this.http.post(this.UrlService , usuarios).pipe(map(super.extractData),catchError(super.serviceError));
    }

    editarUsuario(usuario: Usuarios): Observable<Usuarios> {
        return this.http.put(this.UrlService + usuario.id, usuario).pipe(map(super.extractData),catchError(super.serviceError));
    }

    removerUsuario(id: number): Observable<Usuarios> {
        return this.http.delete(this.UrlService + id).pipe(map(super.extractData),catchError(super.serviceError));
    }
}