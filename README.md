
<h1 align="center">Sistema de Gestión de Pedidos para POS</h1>
<p align="center">Este proyecto fue creado para optimizar, controlar y hacer un seguimiento eficiente de los pedidos semanales de terminales POS</p>


<div>
  <h2>Funcionalidades Principales:</h2>
  <p> ⦁ Cada pedido se registra con un número identificativo y detalles específicos.</p> 
  <p> ⦁ La cantidad de equipos pedidos se compone de la siguiente forma: 
*Equipos ETH
*Equipos Antel
*Equipos Claro
*Equipos Movistar.</p>
  <p> ⦁ Se registra la fecha de ingreso y finalización del pedido. El estado del pedido se actualiza automáticamente a "ENTREGADO" cuando se completa.</p>
</div>

<div>
  <h2>Función de Entrega Parcial:</h2>
  <p> ⦁ Permite entregas parciales durante los cinco días laborables de la semana.</p>
  <p> ⦁ Los números de serie y las partes de los dispositivos entregados se escanean y registran.</p>
  <p> ⦁ Los detalles se muestran en una tabla que incluye el número de serie, el número de parte, el modelo del POS, la compañía del SIM, el tipo de conexión y el ID de terminal.</p>
  <p> ⦁ Se proporciona un resumen de la entrega, incluyendo la cantidad total de POS entregados, desglosados por compañía SIM y modelo.</p>
</div>

<div>
  <h2>Notificación de Pedidos Atrasados:</h2>
  <p> ⦁ Si un pedido no se ha completado en 7 días desde su fecha de ingreso, se muestra un mensaje de "ATRASADO".</p>
</div>

<div>
  <h2>Generación de Documentos:</h2>
  <p> ⦁ Permite la generación de un PDF con todos los detalles del pedido para enviarlo por correo electrónico al cliente y a los superiores.</p>
  <p> ⦁ El PDF puede usarse como remito y proporciona una documentación detallada del pedido.</p>
</div>

<div>
  <h2>Estado del Pedido:</h2>
  <p> ⦁ SIN REALIZAR: El pedido ha sido registrado pero no se ha iniciado.</p>
  <p> ⦁ EN PROCESO: El pedido está en proceso de ser entregado parcialmente.</p>
  <p> ⦁ ENTREGADO: Todos los dispositivos del pedido han sido entregados y el pedido está completo.</p>
</div>

<p>Este sistema ha sido diseñado para proporcionar un control exhaustivo sobre los pedidos de POS, asegurando entregas precisas y oportunas a nuestros clientes.</p>


<div>
  <h2>Instrucciones de Instalación</h2>
  <p>Para ejecutar este proyecto en tu máquina local, asegúrate de tener .NET SDK y Visual Studio (o Visual Studio Code) instalados. Además, el proyecto utiliza las siguientes dependencias de NuGet:</p>
  <p>Microsoft.AspNetCore.Identity.EntityFrameworkCore (7.0.10)</p>
  <p>Microsoft.AspNetCore.Identity.UI (7.0.10)</p>
  <p>Microsoft.EntityFrameworkCore (8.0.0-preview.6.23329.4)</p>
  <p>Microsoft.EntityFrameworkCore.SqlServer (8.0.0-preview.6.23329.4)</p>
  <p>Microsoft.EntityFrameworkCore.Tools (8.0.0-preview.6.23329.4)</p>
  <p>Microsoft.VisualStudioWeb.CodeGeneration.Design (7.0.9)</p>
  <p>Microsoft.AspNetCore.Mvc.ViewFeatures (2.2.0)</p>
  <p>Microsoft.Extensions.Identity.Stores (7.0.10)</p>

  <h2>Conexión a la Base de Datos:</h2>
  <p>1. Asegúrate de tener MySQL Server instalado y en funcionamiento en tu máquina local.</p>
  <p>2. En el archivo appsettings.json, configura la cadena de conexión para apuntar a tu base de datos local:</p>
  
  ```js
  "ConnectionStrings": {
      "ConexionSQL": "Server=localhost\\SQLEXPRESS;Database=db_name;User ID=user_id;Password=password;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;"
      }
  ```

<h2>Pasos de Instalacion:</h2>

<h3>1. Clonar Repositorio:</h3>
  <p>git clone https://github.com/agusMz1908/SistemaGestionDePedidos.git</p>
  <p>cd SistemaGestionDePedidos</p>

<h3>2. Restaurar Dependencias:</h3>
<p>dotnet restore</p>

<h3>3. Aplicar Migraciones de Base de Datos:</h3>
<p>dotnet ef database update</p>

<h3>4. Ejecutar el Proyecto:</h4>
<p>dotnet run</p>
</div>






