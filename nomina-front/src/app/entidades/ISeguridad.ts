export interface ICredenciales {
  usuario: string;
  password: string;
}

export interface IRespuestaAutenticacion {
  accessToken: string;
  expireIn: number;
  isLogin: boolean;
}
