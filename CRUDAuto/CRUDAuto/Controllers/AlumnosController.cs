using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Datos;
using Entidades;
using Negocio;
using CRUDAuto.Models;
using Newtonsoft.Json;

namespace CRUDAuto.Controllers
{
    public class AlumnosController : Controller
    {

        NAlumno _nAlumno = new NAlumno();

        NAlumno _oAlumnoClass = new NAlumno();
        NEstado _oEstado = new NEstado();
        NEstatusAlumno _oEstatus = new NEstatusAlumno();
       Alumno _oAlumno = new Alumno();

        // Alumno alumno = new Alumno();

        // GET: Alumnos
        public ActionResult Index()
        {
            List<Alumno> alumnoList = new List<Alumno>();
            List<EstatusAlumno> lstEstatus = _oEstatus.Consultar();
            List<Estado> lstEstados = _oEstado.Consultar();
            alumnoList = _nAlumno.Consultar();


            var linq =

                from alum in alumnoList
                join Estado in lstEstados on alum.idestadoorigen equals Estado.id
                join Estatus in lstEstatus on alum.idEstatus equals Estatus.id



                select new {id = alum.id ,nombre = alum.nombre,primerApellido = alum.primerApellido,segundoApellido = alum.segundoApellido,
                correo = alum.correo, telefono = alum.telefono, fechaNacimiento = alum.fechaNacimiento, curp = alum.curp,
                sueldo = alum.sueldo, idestadoorigen = Estado.nombre, idEstatus = Estatus.nombre};


            string json = JsonConvert.SerializeObject(linq);
            List<AlumnoM> list = JsonConvert.DeserializeObject<List<AlumnoM>>(json);

            return View(list);
        }

        // GET: Alumnos/Details/5
        public ActionResult Details(int id)
        {
            _oAlumno = _oAlumnoClass.Consultar(id);
            return View(_oAlumno);
        }



        // GET: Alumnos/Create
        public ActionResult Create()
        {
            ViewBag.estados = _oEstado.Consultar();

            ViewBag.estatus = _oEstatus.Consultar();

            return View();

         
        }

        // POST: Alumnos/Create
        [HttpPost]
        public ActionResult Create(Alumno alumno)
        {
            try
            {
                _oAlumnoClass.Agregar(alumno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }











        // GET: Alumnos/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.estados = _oEstado.Consultar();

            ViewBag.estatus = _oEstatus.Consultar();

            _oAlumno = _oAlumnoClass.Consultar(id);
            return View(_oAlumno);
        }

        // POST: Alumnos/Edit/5
        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            try
            {
                _oAlumnoClass.Actualizar(alumno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }














        // GET: Alumnos/Delete/5
        public ActionResult Delete(int id)
        {
            _oAlumno = _oAlumnoClass.Consultar(id);
            return View(_oAlumno);
        }

        // POST: Alumnos/Delete/5
        [HttpPost]
        public ActionResult Delete(Alumno alumno, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _oAlumnoClass.Eliminar(alumno);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
