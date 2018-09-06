using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PackTask.ViewModels
{
    class MainWindowViewModel
    {
        public ReactiveCollection<TreeItemContext> TreeItems { get; }
         = new ReactiveCollection<TreeItemContext>();

        public ReactiveCommand ShowSettingCommand { get; } = new ReactiveCommand();
        public ReactiveCommand AddTreeItemCommand { get; } = new ReactiveCommand();

        public MainWindowViewModel()
        {

            int count = 1;
            TreeItems.Add(new TreeItemContext($"hoge{count++}"));
            TreeItems.Add(new TreeItemContext($"hoge{count++}"));
            TreeItems.Add(new TreeItemContext($"hoge{count++}"));

            ShowSettingCommand.Subscribe(() =>
            {
                //設定を開く
            });

            AddTreeItemCommand.Subscribe(() =>
            {
                //アイテムを追加
                TreeItems.Add(new TreeItemContext($"add {count++}"));
            });
        }


    }

    /// <summary>
    /// ツリーのアイテム
    /// </summary>
    internal class TreeItemContext
    {
        public TreeItemContext(string taskName)
        {
            this.TaskName = new ReactiveProperty<string>(taskName);

            ExecuteCommand.Subscribe(() =>
            {
                //実行する
            });

            DeleteCommand.Subscribe(() =>
            {
                //自身を削除
            });
        }
        
        public ReactiveProperty<string> TaskName { get; }

        public ReactiveCommand ExecuteCommand { get; } = new ReactiveCommand();
        public ReactiveCommand DeleteCommand { get; } = new ReactiveCommand();

        public ReactiveCollection<TreeItemContext> Children { get; }
            = new ReactiveCollection<TreeItemContext>();
    }
}
