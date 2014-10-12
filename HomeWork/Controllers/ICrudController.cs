using System;
using Kendo.Mvc.UI;

namespace HomeWork.Controllers
{
    interface ICrudController<T>
    {

        String Create(T t);

        String Read([DataSourceRequest] DataSourceRequest request);

        String Update(T t);

        String Destroy(T t);


    }
}
