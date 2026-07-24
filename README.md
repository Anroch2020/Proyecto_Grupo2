# Proyecto_Grupo2

UCENM - Ingeniería En Sistemas - Implantación De Tecnología - Grupo 2

## 📋 Descripción

Este proyecto es parte del curso de Implantación de Tecnología de Ingeniería en Sistemas en UCENM. Desarrollado en C# con Visual Studio, utiliza el **Krypton Standard Toolkit** para crear interfaces de usuario modernas y profesionales.

## 🛠️ Requisitos Previos

Antes de comenzar, asegúrate de tener instalado lo siguiente:

- [Visual Studio 2022](https://visualstudio.microsoft.com/es/downloads/) (Community, Professional o Enterprise)
- [.NET Framework 4.8.1](https://dotnet.microsoft.com/es-es/download) o superior
- [Git](https://git-scm.com/)

## 📥 Configuración Inicial

### 1. Clonar el Repositorio

```bash
git clone https://github.com/Anroch2020/Proyecto_Grupo2.git
cd Proyecto_Grupo2
```

### 2. Abrir el Proyecto en Visual Studio

1. Abre **Visual Studio**
2. Selecciona **Archivo → Abrir → Proyecto o Solución**
3. Navega a la carpeta del proyecto clonado
4. Selecciona el archivo `.sln` (solución)
5. Haz clic en **Abrir**

### 3. Restaurar Dependencias

Una vez que se abra el proyecto:

1. En el **Explorador de Soluciones**, haz clic derecho sobre la solución
2. Selecciona **Restaurar paquetes NuGet**
3. Espera a que se completen las descargas

Alternativamente, puedes usar la **Consola del Administrador de Paquetes**:

```powershell
Update-Package -Reinstall
```

### 4. Compilar el Proyecto

1. Ve a **Compilar → Compilar Solución** (o presiona `Ctrl + Shift + B`)
2. Verifica que no haya errores en la ventana de **Errores**

### 5. Ejecutar la Aplicación

1. Selecciona el proyecto principal como proyecto de inicio (clic derecho → Establecer como proyecto de inicio)
2. Presiona `F5` o ve a **Depuración → Iniciar Depuración**

## 📁 Estructura del Proyecto

```
Proyecto_Grupo2/
├── Proyecto_Grupo2.sln
├── Proyecto_Grupo2/
│   ├── Properties/
│   ├── bin/
│   ├── obj/
│   ├── Clases/
│   ├── Vistas/
│   ├── Resources/
│   ├── Libs/
│   ├── [Archivos .cs]
│   └── App.config
└── README.md
```

## 📦 Dependencias NuGet

El proyecto utiliza las siguientes dependencias NuGet:

| Paquete | Versión | Descripción |
|---------|---------|-------------|
| **Krypton.Navigator.LTS** | 85.26.6.173 | Toolkit para crear interfaces de usuario profesionales con controles WinForms mejorados |

### Krypton Standard Toolkit

El **Krypton Standard Toolkit** es un conjunto completo de controles para Windows Forms que proporciona:

- Controles UI modernos y personalizables
- Temas predefinidos y personalizables
- Estilos profesionales para botones, menús, barras de herramientas y navegadores
- Mejora significativa de la experiencia visual de la aplicación
- Documentación completa y ejemplos

Para más información, visita: [Krypton Toolkit](https://github.com/Krypton-Suite/Standard-Toolkit)

## 🔧 Configuración Adicional

### Cambiar la Configuración de Compilación

- **Debug**: Para desarrollo y depuración
- **Release**: Para distribución final

Selecciona la configuración deseada en la barra de herramientas de Visual Studio.

### Instalar Paquetes NuGet Adicionales

Si necesitas agregar más paquetes:

1. **Consola del Administrador de Paquetes**: `Tools → NuGet Package Manager → Package Manager Console`
2. Ejecuta: `Install-Package NombreDelPaquete`

O usa el **Administrador de Paquetes NuGet**: `Tools → NuGet Package Manager → Manage NuGet Packages for Solution`

## 📚 Documentación Útil

- [Documentación de C#](https://docs.microsoft.com/es-es/dotnet/csharp/)
- [Guía de Visual Studio](https://docs.microsoft.com/es-es/visualstudio/)
- [NuGet Package Manager](https://www.nuget.org/)
- [Krypton Toolkit Documentación](https://github.com/Krypton-Suite/Standard-Toolkit/blob/master/Documents/palette-mechanics-intro.md)

## 👥 Integrantes del Grupo

- (Agregar nombres de los integrantes)

## 📝 Licencia

Este proyecto es parte del curso de Ingeniería en Sistemas de UCENM.

---

**Última actualización:** 2026-07-24
