# DescargaMasivaSAT

Solución para la descarga masiva del nuevo WS-SAT

## Comenzando 🚀
Urls:
Autenticación :
https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/Autenticacion/Autenticacion.svc

Solicitud:
https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/SolicitaDescargaService.svc

Verificación: 
https://cfdidescargamasivasolicitud.clouda.sat.gob.mx/VerificaSolicitudDescargaService.svc

Descarga: 
https://cfdidescargamasiva.clouda.sat.gob.mx/DescargaMasivaService.svc


Ejemplo: 

            // 1) Autenticación al SAT,
            // una ves autenticado nos devolvera un token, donde podremos 
            // consumir los demas WS del sAT.
            IAutenticacion autenticador = descargaMasiva.autenticar(parametro);


            // /// 2) Solicitud para petición de una consulta con los parametros, 
            // /// se necesita tener un token vigente, si no lo rechazará.
           // ISolicitudDescarga solicitudDescarga =  descargaMasiva.solicitudDescarga(parametro, autenticador.getToken());

          
            // 3) Verificamos el estatus de nuestra consulta realizada previamente, para ello necesitamos tener
            //    un token valido y un idSolicitud.
            //    Los estatos  a consultar son:
            //  -EnProceso.
            //  -Aceptada
            //  -Terminada
            //  -Error
            //  -Rechazada
            //  -Vencida
            IVerificarSolicitud<VerificadorMeta, TipoEstatus> verificar = descargaMasiva.verificadorDescarga(parametro, autenticador.getToken(), solicitud);


            //Iniciamos un ciclo, hasta que la consz
            while (!verificar.isTerminada())
            {
                Thread.Sleep(1000);
            }

            //Una ves que la verificación termine con el estatus Terminado, se iniciara la extracción de los Folios. 
            // TODO: Por el momento le tenemos que pasar un folio, pero es necesario tener otro método que permita agregar todos.
            foreach (string idPaquete in verificar.getListaFolios())
            {
                IDescargaMasiva descarga = descargaMasiva.descargaMasiva(parametro, autenticador.getToken(), idPaquete, parametro.RFCSolicitane.getValor());



                Directory.CreateDirectory(path);

                using (FileStream fs = File.Create(path + new Random().Next(0, 1000000).ToString() + ".zip", descarga.getIdPaqueteFromBase64String().Length))
                {
                    fs.Write(descarga.getIdPaqueteFromBase64String(), 0, descarga.getIdPaqueteFromBase64String().Length);
                    fs.Close();
                }
                Console.WriteLine("FileCreated: " + path + idPaquete + ".zip");

            }


## Autor ✒️

ISC.Magdiel Efrain Palacios Rivera.
