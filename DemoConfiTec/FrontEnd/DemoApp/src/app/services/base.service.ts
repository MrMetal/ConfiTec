import { HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { throwError } from "rxjs";

export abstract class BaseService {  

    protected extractData(response: any) {
        return response.data || {};
    }

    protected serviceError(response: Response | any) {
        let customError: string[] = [];
        let customResponse = { error: { errors: [] } }
        let responseErros: any;

        if (response instanceof HttpErrorResponse) {

            if (response.statusText === "Unknown Error") {
                response.error.errors = customError.push("Ocorreu um erro desconhecido");
            }
        }
        if (response.status === 500) {
            customError.push("Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.");
            customResponse.error.errors = customError;
            return throwError(customResponse);
        }
        if (response.status === 400) {

            for (const campo in response.error.errors) {
                if (response.error.errors.hasOwnProperty(campo)) {

                    if (response.error.errors.length >= 1) {
                        responseErros = response.error.errors;  

                        for (const erro in responseErros) customError.push(responseErros[erro]);

                        customResponse.error.errors = customError;
                        return throwError(customResponse);
                    }

                    responseErros = response.error.errors[campo];

                    for (const erro in responseErros) customError.push(responseErros[erro]);
                   
                    customResponse.error.errors = customError;
                }
            }
            return throwError(customResponse);
        }

        console.error(response);
        return throwError(response);
    }
}