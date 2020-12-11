# SpotQualityManagement

Este proyecto consta de tres endpoints: uno para calcular la puntuación de un anuncio en base a unas reglas de puntuación específicas, otro endpoint para obtener todos los anuncios relevantes para el usuario ordenados de mejor a peor puntuación y un último endpoint para obtener todos los anuncios que son irrelevantes para el usuario para el departamento de calidad de cara a valorar su irrelevancia.

Para los dos endpoints de consulta, he usado un servicio de query donde se hace una obtención de los datos necesitados y se mapean a una entidad respuesta que espera el usuario.
Para el endpoint de calcular la puntuación, he usado la herramienta MediatR para llamar a un handler que a su vez llamará a un servicio donde se aplican todas las reglas de cálculo de la puntuación final del anuncio.

Este proyecto también cuenta con dos proyectos de test, un proyecto de test funcional y otro para test unitarioas. Los test funcionales prueban el flujo completo de cada endpoint mientras que los test unitarias prueban únicamente métodos concretos. En algunos de los test he usado la librería Mock para mockear ciertas partes que he considerado.
