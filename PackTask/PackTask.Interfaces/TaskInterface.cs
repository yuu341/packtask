using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PackTask.Interfaces
{
    /// <summary>
    /// 表示物の基本単位
    /// </summary>
    public interface IContent
    {
        /// <summary>
        /// 開く
        /// </summary>
        void Show();
    }

    /// <summary>
    /// パッケージ
    /// </summary>
    public interface IPackage : IContent
    {
        IEnumerable<IContent> Children { get; }
    }

    /// <summary>
    /// タスク
    /// </summary>
    public interface ITask : IContent
    {
        /// <summary>
        /// タスクが実行時に持っている変数群。これ以外に値は使用不可
        /// </summary>
        IEnumerable<IVariable> Values { get; }
    }

    /// <summary>
    /// タスクの実行結果
    /// </summary>
    public interface IResult
    {
        
    }

    /// <summary>
    /// 内部で保持されている変数
    /// </summary>
    public interface IVariable
    {
        VariableType VariableType { get; }
        SourceType SourceType { get; set; }

        

    }

    /// <summary>
    /// どこからこの変数を得るか
    /// </summary>
    public enum SourceType
    {
        /// <summary>
        /// 環境情報
        /// </summary>
        Environment,
        /// <summary>
        /// 以前のタスクが実行し貯めておいたもの
        /// </summary>
        VariablePool,
    }
    /// <summary>
    /// どういう
    /// </summary>
    public enum VariableType
    {
        
    }
}
