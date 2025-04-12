import {Injectable} from '@angular/core';
import swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class MensajesService {
  constructor() {
  }

  Error(strTitulo: string, strMensaje: string) {
    this.Mensaje3parametros('error', strTitulo, strMensaje);
  }

  Correcto(strTitulo: string, strMensaje: string) {
    this.Mensaje3parametros('success', strTitulo, strMensaje);
  }

  Advertencia(strTitulo: string, strMensaje: string) {
    this.Mensaje3parametros('warning', strTitulo, strMensaje);
  }

  Mensaje3parametros(strTipo: any, strTitulo: string, strMensaje: string) {
    swal.fire({
      icon: strTipo,
      title: strTitulo,
      text: strMensaje,
    });
  }


  // Confirmacion(strTitulo: string, strMensaje: string, onSucess: () => void): void {
  //   swal.fire({
  //     title: strTitulo,
  //     text: strMensaje,
  //     icon: 'warning',
  //     showCancelButton: true,
  //     confirmButtonColor: '#3085d6',
  //     cancelButtonColor: '#d33'
  //   }).then((result) => {
  //     if (result.isConfirmed) {
  //       onSucess();
  //     }
  //   });
  // }

  // ConfirmacionYesNoAnswer(strTitulo: string, strMensaje: string, onYesAnswer: () => void, onNoAnswer: () => void): void {
  //   swal.fire({
  //     title: strTitulo,
  //     text: strMensaje,
  //     icon: 'warning',
  //     showCancelButton: true,
  //     confirmButtonColor: '#3085d6',
  //     cancelButtonColor: '#d33'
  //   }).then((result) => {
  //     if (result.isConfirmed) {
  //       onYesAnswer();
  //     } else {
  //       onNoAnswer();
  //     }
  //   });
  // }


}
