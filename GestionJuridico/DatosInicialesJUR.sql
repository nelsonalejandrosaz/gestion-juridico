USE [GestionJuridicoDb]
GO
SET IDENTITY_INSERT [dbo].[TiposDocumento] ON 
GO
INSERT [dbo].[TiposDocumento] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'D', N'DUI', 0)
GO
INSERT [dbo].[TiposDocumento] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'N', N'NIT', 0)
GO
INSERT [dbo].[TiposDocumento] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (3, N'P', N'Pasaporte', 0)
GO
SET IDENTITY_INSERT [dbo].[TiposDocumento] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposEntidad] ON 
GO
INSERT [dbo].[TiposEntidad] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'PJ', N'Persona jurídica', 0)
GO
INSERT [dbo].[TiposEntidad] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'PN', N'Persona natural', 0)
GO
SET IDENTITY_INSERT [dbo].[TiposEntidad] OFF
GO
SET IDENTITY_INSERT [dbo].[Procesos] ON 
GO
INSERT [dbo].[Procesos] ([Id], [Codigo], [Nombre], [Descripcion], [AccionInicialId], [isDeleted]) VALUES (1, N'S', N'Solicitud jurídico', N'Proceso de solicitud de jurídico', NULL, 0)
GO
INSERT [dbo].[Procesos] ([Id], [Codigo], [Nombre], [Descripcion], [AccionInicialId], [isDeleted]) VALUES (2, N'C', N'Caso jurídico', N'Proceso de caso jurídico', NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Procesos] OFF
GO
SET IDENTITY_INSERT [dbo].[Estados] ON 
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (1, N'S000', N'Por ingresar', NULL, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (2, N'S001', N'Ingresado', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (3, N'S002', N'Asignado', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (4, N'S003', N'En análisis', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (5, N'S004', N'En elaboración de documento', 5, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (6, N'S005', N'En revisión de documento', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (7, N'S006', N'En corrección de observaciones', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (8, N'S007', N'En firma de superintendente', NULL, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (9, N'S008', N'En elaboración de notificación', 2, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (10, N'S009', N'En proceso de notificación', 5, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (11, N'S010', N'Notificado y finalizado', NULL, 1, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (12, N'C000', N'Por ingresar', NULL, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (13, N'C001', N'Abierto', 2, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (14, N'C002', N'En proceso', 2, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (15, N'C003', N'En requerimiento de informe técnico', 20, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (16, N'C004', N'En prevención y requerimiento de informe técnico', 20, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (17, N'C005', N'En prevención', 10, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (18, N'C006', N'Archivado', NULL, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (19, N'C007', N'En prevención técnica', 10, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (20, N'C008', N'En autorización de inscripción', 5, 2, 0)
GO
INSERT [dbo].[Estados] ([Id], [Codigo], [Nombre], [DiasPlazo], [ProcesoId], [isDeleted]) VALUES (21, N'C009', N'Finalizado y cerrado', NULL, 2, 0)
GO
SET IDENTITY_INSERT [dbo].[Estados] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposAccion] ON 
GO
INSERT [dbo].[TiposAccion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'CO', N'Común', 0)
GO
INSERT [dbo].[TiposAccion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'AS', N'Asignación', 0)
GO
INSERT [dbo].[TiposAccion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (3, N'FI', N'Finalización', 0)
GO
SET IDENTITY_INSERT [dbo].[TiposAccion] OFF
GO
SET IDENTITY_INSERT [dbo].[Acciones] ON 
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (1, N'S000', N'Ingresar', N'Ingresar', 1, 2, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (2, N'S001', N'Asignar', N'Asignar', 2, 3, 2, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (3, N'S002', N'Iniciar análisis', N'Iniciar análisis', 3, 4, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (4, N'S003', N'Elaborar documento', N'Elaborar documento', 4, 5, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (5, N'S004', N'Solicitar aprobación de documento ', N'Solicitar aprobación de documento ', 5, 6, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (6, N'S005', N'Observar documento', N'Observar documento', 6, 7, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (7, N'S006', N'Aprobar documento', N'Aprobar documento', 6, 8, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (8, N'S007', N'Solicitar aprobación de documento ', N'Solicitar aprobación de documento ', 7, 6, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (10, N'S009', N'Notificar', N'Notificar', 9, 10, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (11, N'S008', N'Firmado', N'Firmado', 8, 9, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (12, N'S010', N'Notificado', N'Notificado', 10, 11, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (13, N'C000', N'Abrir caso', N'Iniciar caso', 12, 13, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (14, N'C001', N'Iniciar caso', N'Iniciar caso', 13, 14, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (15, N'C002', N'Solicitar informe técnico ', N'Solicitar informe técnico ', 14, 15, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (16, N'C003', N'Prevenir y solicitar informe técnico', N'Prevenir y solicitar informe técnico', 14, 16, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (17, N'C004', N'Prevenir', N'Prevenir', 14, 17, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (18, N'C005', N'Archivar caso', N'Archivar caso', 17, 18, 3, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (19, N'C006', N'Solicitar informe técnico ', N'Solicitar informe técnico ', 17, 15, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (20, N'C007', N'Autorizar inscripción', N'Autorizar inscripción', 15, 20, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (21, N'C008', N'Prevenir (técnico)', N'Prevenir (técnico)', 15, 19, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (22, N'C009', N'Solicitar informe técnico ', N'Solicitar informe técnico ', 19, 15, 1, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (23, N'C010', N'Archivar caso', N'Archivar caso', 19, 18, 3, 0)
GO
INSERT [dbo].[Acciones] ([Id], [Codigo], [Nombre], [Descripcion], [EstadoActualId], [EstadoSiguienteId], [TipoAccionId], [isDeleted]) VALUES (24, N'C011', N'Cerrar caso', N'Cerrar caso', 20, 21, 3, 0)
GO
SET IDENTITY_INSERT [dbo].[Acciones] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposActo] ON 
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'AC', N'Acuerdo', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'RE', N'Resolución', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (3, N'IJ', N'Informe jurídico', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (4, N'CA', N'Carta', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (5, N'ME', N'Memorándum ', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (6, N'CO', N'Contrato', 0)
GO
INSERT [dbo].[TiposActo] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (7, N'OP', N'Opinión', 0)
GO
SET IDENTITY_INSERT [dbo].[TiposActo] OFF
GO
SET IDENTITY_INSERT [dbo].[TiposEmisor] ON 
GO
INSERT [dbo].[TiposEmisor] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'SI', N'Superintendente', 0)
GO
INSERT [dbo].[TiposEmisor] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'JO', N'Junta de directores ordinaria', 0)
GO
INSERT [dbo].[TiposEmisor] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (3, N'JE', N'Junta de directores extraordinaria', 0)
GO
INSERT [dbo].[TiposEmisor] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (4, N'GL', N'Gerencia Legal', 0)
GO
INSERT [dbo].[TiposEmisor] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (5, N'OT', N'Otros gerentes o jefaturas', 0)
GO
SET IDENTITY_INSERT [dbo].[TiposEmisor] OFF
GO
SET IDENTITY_INSERT [dbo].[UnidadesInstitucion] ON 
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (1, N'GE', N'Electricidad', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (2, N'GT', N'Telecomunicaciones', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (3, N'AD', N'Administrativo', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (4, N'TH', N'Talento Humano', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (5, N'RE', N'Registro', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (6, N'CA', N'Centro Atención al Usuario', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (7, N'AD', N'UACI', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (8, N'DS', N'Dirección Superior', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (9, N'GF', N'Financiero', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (10, N'OI', N'OIR', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (11, N'AI', N'Auditoría Interna', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (12, N'IN', N'Informática', 0)
GO
INSERT [dbo].[UnidadesInstitucion] ([Id], [Codigo], [Nombre], [isDeleted]) VALUES (13, N'GJ', N'Jurídico', 0)
GO
SET IDENTITY_INSERT [dbo].[UnidadesInstitucion] OFF
GO
