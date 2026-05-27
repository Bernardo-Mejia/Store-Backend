using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace DXStore.Module.BusinessObjects.Catalogos
{
    [DefaultClassOptions]
    [NavigationItem("Catálogos")]
    [ImageName("ModelEditor_Action_Schema")]
    public class Categoria : XPObject
    {
        public Categoria() : base()
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public Categoria(Session session) : base(session)
        {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place here your initialization code.
            this.FechaCreacion = DateTime.Now;
        }

        private string _Nombre;
        [RuleUniqueValue]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Nombre
        {
            get => _Nombre;
            set => SetPropertyValue(nameof(Nombre), ref _Nombre, value);
        }

        private string _Slug;
        [Size(200)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Slug
        {
            get => _Slug;
            set => SetPropertyValue(nameof(Slug), ref _Slug, value);
        }

        private string _Descripcion;
        [Size(SizeAttribute.Unlimited)]
        [RuleRequiredField(DefaultContexts.Save)]
        public string Descripcion
        {
            get => _Descripcion;
            set => SetPropertyValue(nameof(Descripcion), ref _Descripcion, value);
        }

        private bool _Activo;
        public bool Activo
        {
            get => _Activo;
            set => SetPropertyValue(nameof(Activo), ref _Activo, value);
        }

        private int _Orden;
        public int Orden
        {
            get => _Orden;
            set => SetPropertyValue(nameof(Orden), ref _Orden, value);
        }

        private DateTime _FechaCreacion;
        [XafDisplayName("Fecha de Creación")]
        [ModelDefault("AllowEdit", "False")]
        [ModelDefault("DisplayFormat", "{0:G}")]
        [ModelDefault("EditMask", "G")]
        public DateTime FechaCreacion
        {
            get => _FechaCreacion;
            set => SetPropertyValue(nameof(FechaCreacion), ref _FechaCreacion, value);
        }

        private Categoria _CategoriaPadre;
        [Association("Categoria-CategoriasHijas")]
        [XafDisplayName("Categoría Padre")]
        public Categoria CategoriaPadre
        {
            get => _CategoriaPadre;
            set => SetPropertyValue(nameof(CategoriaPadre), ref _CategoriaPadre, value);
        }

        [Association("Categoria-CategoriasHijas"), DevExpress.Xpo.Aggregated]
        [XafDisplayName("Categorías Hijas")]
        public XPCollection<Categoria> Categorias
        {
            get { return GetCollection<Categoria>(nameof(Categorias)); }
        }
    }
}