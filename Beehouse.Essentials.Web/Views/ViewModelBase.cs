using Beehouse.Essentials.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beehouse.Essentials.Web.Views
{
    public class ViewModelBase<TModel>
    {
        public string Id { get; set; }
        public ViewModelState State { get; set; }

        public Func<TModel, ViewModelBase<TModel>> ToViewModelMap;
        public Func<TModel> ToModelMap;
    }

    public static class ViewModelBaseExtensions{
        public static ViewModelBase<TModel> SetModel<TModel>(this ViewModelBase<TModel> view, TModel model)
        {
            return view.ToViewModelMap.Invoke(model);
        }

        public static TModel GetModel<TModel>(this ViewModelBase<TModel> view)
        {
            return view.ToModelMap.Invoke();
        }
    }
}
