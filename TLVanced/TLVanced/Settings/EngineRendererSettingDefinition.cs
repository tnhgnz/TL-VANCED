namespace TLVanced
{
    public sealed class EngineRendererSettingDefinition
    {
        public required string Key { get; init; }
        public required string RecommendedValue { get; init; }
        public required string AllowedValues { get; init; }
        public required string Description { get; init; }

        public static IReadOnlyList<EngineRendererSettingDefinition> All { get; } =
        [
            new()
            {
                Key = "r.HairStrands.Enable",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. весь groom/strands/cards/meshes, 1 — вкл.",
                Description = "Волосы Groom / strands (объёмные пряди и карточки) — полное отключение системы."
            },
            new()
            {
                Key = "r.HairStrands.Cards",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. hair cards (нужен перезапуск/перезагрузка уровня в части билдов)",
                Description = "Отрисовка волос как карт (cards) — дополнительное отключение к strands."
            },
            new()
            {
                Key = "r.SkyAtmosphere",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл. (Sky Atmosphere)",
                Description = "Физическая атмосфера неба (UE4.24+); выкл. даёт +FPS на слабом железе."
            },
            new()
            {
                Key = "r.DefaultFeature.AntiAliasing",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. MSAA, 1 — вкл.",
                Description = "Сглаживание (MSAA) по умолчанию."
            },
            new()
            {
                Key = "r.PostProcessAAQuality",
                RecommendedValue = "0",
                AllowedValues = "0–6 (TAA/FXAA), 0 — минимум",
                Description = "Качество пост-AA (TAA/FXAA и т.п.)."
            },
            new()
            {
                Key = "r.DefaultFeature.AmbientOcclusion",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "SSAO по умолчанию."
            },
            new()
            {
                Key = "r.AmbientOcclusionLevels",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1+ — уровни/качество",
                Description = "Уровни / качество ambient occlusion."
            },
            new()
            {
                Key = "r.MotionBlur.Max",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., выше — сила размытия",
                Description = "Верхний предел силы motion blur."
            },
            new()
            {
                Key = "r.MotionBlurQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1–4 — качество",
                Description = "Качество и стоимость motion blur."
            },
            new()
            {
                Key = "r.DefaultFeature.MotionBlur",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Motion blur по умолчанию."
            },
            new()
            {
                Key = "r.DepthOfFieldQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1+ — качество DoF",
                Description = "Качество глубины резкости (Depth of Field)."
            },
            new()
            {
                Key = "r.DefaultFeature.Bloom",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Bloom по умолчанию."
            },
            new()
            {
                Key = "r.BloomQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин., выше — качество",
                Description = "Качество эффекта bloom."
            },
            new()
            {
                Key = "grass.Enable",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Трава на ландшафте (landscape grass)."
            },
            new()
            {
                Key = "grass.densityScale",
                RecommendedValue = "0",
                AllowedValues = "0 — нет плотности, 0.5–1 — норма",
                Description = "Множитель плотности травы (меньше — меньше травинок)."
            },
            new()
            {
                Key = "grass.CullDistanceScale",
                RecommendedValue = "0.5",
                AllowedValues = "меньше — раньше отсекается по дистанции",
                Description = "Множитель дистанций отсечения травы."
            },
            new()
            {
                Key = "grass.DiscardDataOnLoad",
                RecommendedValue = "1",
                AllowedValues = "1 — не грузить данные травы (нужна перезагрузка уровня)",
                Description = "Полное отключение данных травы при загрузке (жёстче чем grass.Enable)."
            },
            new()
            {
                Key = "grass.DisableDynamicShadows",
                RecommendedValue = "1",
                AllowedValues = "1 — без динамических теней от травы",
                Description = "Отключить динамические тени у травы."
            },
            new()
            {
                Key = "foliage.MaxTrianglesToRender",
                RecommendedValue = "0",
                AllowedValues = "0 — минимум, выше — лимит треугольников за проход",
                Description = "Лимит треугольников foliage за кадр."
            },
            new()
            {
                Key = "foliage.LODDistanceScale",
                RecommendedValue = "0",
                AllowedValues = "0 — агрессивный LOD, 1 — по умолчанию",
                Description = "Масштаб дистанции LOD для листвы/кустов."
            },
            new()
            {
                Key = "foliage.DensityScale",
                RecommendedValue = "0",
                AllowedValues = "0 — минимум экземпляров (тип должен поддерживать scaling)",
                Description = "Плотность инстансов foliage (если тип подписан на density scale)."
            },
            new()
            {
                Key = "foliage.MinLOD",
                RecommendedValue = "1",
                AllowedValues = "-1 выкл., 0+ — отбросить верхние LOD (ниже деталь)",
                Description = "Отбрасывает верхние LOD листвы (грубее модель раньше)."
            },
            new()
            {
                Key = "foliage.ForceLOD",
                RecommendedValue = "3",
                AllowedValues = "≥0 — зафиксировать LOD уровень (зависит от числа LOD)",
                Description = "Принудительный LOD foliage для теста производительности."
            },
            new()
            {
                Key = "fx.EnableNiagaraSpriteRendering",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. спрайты Niagara, 1 — вкл.",
                Description = "Niagara: спрайты (часто частицы скиллов / VFX)."
            },
            new()
            {
                Key = "fx.EnableNiagaraMeshRendering",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. mesh renderer Niagara",
                Description = "Niagara: меши в эффектах."
            },
            new()
            {
                Key = "fx.EnableNiagaraRibbonRendering",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл. ribbon Niagara",
                Description = "Niagara: ленты / трейлы."
            },
            new()
            {
                Key = "fx.MaxNiagaraGPUParticlesSpawnPerFrame",
                RecommendedValue = "64",
                AllowedValues = "меньше — меньше спавн GPU частиц за кадр",
                Description = "Лимит спавна GPU-частиц Niagara за кадр (сдерживает тяжёлые скиллы)."
            },
            new()
            {
                Key = "fx.MaxNiagaraCPUParticlesPerEmitter",
                RecommendedValue = "256",
                AllowedValues = "меньше — меньше CPU частиц на эмиттер",
                Description = "Максимум CPU-частиц на эмиттер Niagara."
            },
            new()
            {
                Key = "r.ParticleLightQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин., выше — освещение от частиц",
                Description = "Качество освещения от частиц (вспышки скиллов и т.д.)."
            },
            new()
            {
                Key = "r.Fog",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Туман (height fog / классический)."
            },
            new()
            {
                Key = "r.DefaultFeature.LightUnits",
                RecommendedValue = "0",
                AllowedValues = "0/1 — режим единиц света",
                Description = "Единицы интенсивности света по умолчанию."
            },
            new()
            {
                Key = "r.DefaultFeature.AutoExposure",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — автоэкспозиция",
                Description = "Автоэкспозиция по умолчанию."
            },
            new()
            {
                Key = "r.MipMapLODBias",
                RecommendedValue = "0",
                AllowedValues = "<0 резче, >0 мыльнее",
                Description = "Смещение mip-уровней текстур."
            },
            new()
            {
                Key = "r.Tonemapper.Quality",
                RecommendedValue = "2",
                AllowedValues = "0–5",
                Description = "Качество тонмаппера (HDR → LDR)."
            },
            new()
            {
                Key = "r.Tonemapper.Sharpen",
                RecommendedValue = "1",
                AllowedValues = "0 / 0.5 / 1 и выше — сила резкости",
                Description = "Резкость тонмаппера (часто 0.5–1 компромисс без шума)."
            },
            new()
            {
                Key = "r.VolumetricCloud",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1+ — качество",
                Description = "Объёмные облака."
            },
            new()
            {
                Key = "r.VolumetricFog",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Объёмный туман."
            },
            new()
            {
                Key = "r.Postprocessing.DisableMaterials",
                RecommendedValue = "1",
                AllowedValues = "0 — вкл., 1 — отключить пост-материалы",
                Description = "Постобработка через материалы (часто +FPS)."
            },
            new()
            {
                Key = "r.ViewDistanceScale",
                RecommendedValue = "0.8",
                AllowedValues = "0.1–1.0",
                Description = "Глобальный масштаб дистанции отсечения объектов."
            },
            new()
            {
                Key = "r.DetailMode",
                RecommendedValue = "0",
                AllowedValues = "0 low, 1 medium, 2 high",
                Description = "Режим детализации акторов (меньше — меньше мелочей в кадре)."
            },
            new()
            {
                Key = "r.MaterialQualityLevel",
                RecommendedValue = "0",
                AllowedValues = "0 low, 1 high, 2 medium (зависит от проекта)",
                Description = "Уровень качества материалов (агрегат для шейдеров)."
            },
            new()
            {
                Key = "r.ShadowQuality",
                RecommendedValue = "0",
                AllowedValues = "0–5",
                Description = "Качество теней (профиль)."
            },
            new()
            {
                Key = "r.Shadow.MaxCSMResolution",
                RecommendedValue = "1024",
                AllowedValues = "512, 1024, 2048… разрешение CSM",
                Description = "Макс. разрешение каскадных карт теней."
            },
            new()
            {
                Key = "r.Shadow.CSM.MaxCascades",
                RecommendedValue = "2",
                AllowedValues = "1–4 число каскадов",
                Description = "Число каскадов CSM (меньше — быстрее)."
            },
            new()
            {
                Key = "r.DistanceFieldShadowing",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "DF shadows."
            },
            new()
            {
                Key = "r.ContactShadows",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Контактные тени."
            },
            new()
            {
                Key = "r.CapsuleShadows",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Капсульные тени на скине."
            },
            new()
            {
                Key = "r.SSR.Quality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин./выкл., выше — SSR",
                Description = "Screen space reflections."
            },
            new()
            {
                Key = "r.DefaultFeature.LensFlare",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл., 1 — вкл.",
                Description = "Lens flare по умолчанию."
            },
            new()
            {
                Key = "r.LensFlareQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин.",
                Description = "Качество lens flare."
            },
            new()
            {
                Key = "r.SceneColorFringeQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — выкл.",
                Description = "Хроматическая аберрация у края кадра."
            },
            new()
            {
                Key = "r.EyeAdaptationQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин.",
                Description = "Качество eye adaptation / гистограммы."
            },
            new()
            {
                Key = "r.SeparateTranslucency",
                RecommendedValue = "0",
                AllowedValues = "0/1",
                Description = "Отдельный проход translucency."
            },
            new()
            {
                Key = "r.TranslucencyLightingVolumeDim",
                RecommendedValue = "32",
                AllowedValues = "32, 48, 64…",
                Description = "Размер объёма освещения для полупрозрачности."
            },
            new()
            {
                Key = "r.LightFunctionQuality",
                RecommendedValue = "0",
                AllowedValues = "0 — мин.",
                Description = "Light functions."
            },
            new()
            {
                Key = "r.ReflectionEnvironmentLightmapMix",
                RecommendedValue = "0",
                AllowedValues = "0–1",
                Description = "Смесь reflection environment и lightmap."
            },
            new()
            {
                Key = "r.MaxAnisotropy",
                RecommendedValue = "4",
                AllowedValues = "0, 2, 4, 8, 16",
                Description = "Анизотропная фильтрация текстур."
            },
            new()
            {
                Key = "r.SkeletalMeshLODBias",
                RecommendedValue = "1",
                AllowedValues = "0+, целое — сдвиг LOD скелетных мешей",
                Description = "Сдвиг LOD персонажей/оружия (грубее дальше от камеры)."
            },
            new()
            {
                Key = "r.DefaultFeature.AmbientOcclusionStaticFraction",
                RecommendedValue = "0",
                AllowedValues = "0 — без доп. прохода AO на статике, 1 — полный эффект",
                Description = "Статическая доля AO (доп. проход при запечённом свете)."
            },
            new()
            {
                Key = "r.AmbientOcclusionRadiusScale",
                RecommendedValue = "0.5",
                AllowedValues = "0.1–2.0",
                Description = "Радиус SSAO (меньше — дешевле)."
            },
            new()
            {
                Key = "r.LightMaxDrawDistanceScale",
                RecommendedValue = "0.8",
                AllowedValues = "0–1+",
                Description = "Масштаб MaxDrawDistance у источников света."
            },
            new()
            {
                Key = "r.GenerateMeshDistanceFields",
                RecommendedValue = "0",
                AllowedValues = "0/1 (пересборка мешей; осторожно)",
                Description = "Построение mesh distance fields (нужно для части эффектов; выкл. экономит память/CPU)."
            },
            new()
            {
                Key = "r.AllowOcclusionQueries",
                RecommendedValue = "1",
                AllowedValues = "0/1 — occlusion queries",
                Description = "HW occlusion queries (0 может ухудшить картину CPU/GPU баланса)."
            },
            new()
            {
                Key = "r.Streaming.PoolSize",
                RecommendedValue = "1000",
                AllowedValues = "МБ",
                Description = "Пул стриминга текстур."
            },
            new()
            {
                Key = "r.VSync",
                RecommendedValue = "0",
                AllowedValues = "0/1",
                Description = "VSync."
            },
            new()
            {
                Key = "r.OneFrameThreadLag",
                RecommendedValue = "1",
                AllowedValues = "0/1",
                Description = "Параллелизм рендера (+возможная задержка ввода)."
            },
        ];
    }
}
