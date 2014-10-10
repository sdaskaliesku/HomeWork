using System;
using System.Web.Mvc;
using Kendo.Mvc.UI;

namespace HomeWork.Controllers
{
    interface ICrudController<T>
    {

        ActionResult Create(T t);

        String Read([DataSourceRequest] DataSourceRequest request);

        ActionResult Update(T t);

        ActionResult Destroy(T t);


    }
}
