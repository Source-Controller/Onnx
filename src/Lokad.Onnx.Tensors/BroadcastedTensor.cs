﻿namespace Lokad.Onnx;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

public class BroadcastedTensor<T> : Tensor<T> where T :  struct
{
    #region Constructor
    public BroadcastedTensor(Tensor<T> source, ReadOnlySpan<int> dimensions, int[] broadcastedDims) : 
        base(dimensions, false)
    {
        if (broadcastedDims.Length == 0)
        {
            throw new ArgumentException(nameof(broadcastedDims), "The number of broadcasted dimensions cannot be 0.");
        }
        if (broadcastedDims.Length > dimensions.Length) 
        { 
            throw new ArgumentException(nameof(broadcastedDims), "The number of broadcasted dimensions cannot be more than the number of source dimensions.");
        }
        this.source = source;
        this.broadcastedDims = broadcastedDims;  
    }
    #endregion

    #region Methods

    #region Tensor<T> members
    public override T GetValue(int index)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        int[] indices = new int[this.Rank];
        ArrayUtilities.GetIndices(strides, IsReversedStride, index, indices);
        return source.GetValue(ArrayUtilities.GetIndex(source.strides, indices, broadcastedDims));
    }

    public override void SetValue(int index, T value)
    {
        if (index >= Length) throw new IndexOutOfRangeException();
        int[] indices = new int[this.Rank];
        ArrayUtilities.GetIndices(strides, IsReversedStride, index, indices);
        this.source.SetValue(ArrayUtilities.GetIndex(source.strides, indices, broadcastedDims), value);
    }

    /// <summary>
    /// Obtains the value at the specified indices
    /// </summary>
    /// <param name="indices">A span integers that represent the indices specifying the position of the element to get.</param>
    /// <returns>The value at the specified position in this Tensor.</returns>
    public override T this[ReadOnlySpan<int> indices]
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get
        {
            if (indices.Length == 1 && Rank == 0 && indices[0] == 0)
            {
                return GetValue(0);
            }
            for (int i = 0; i < indices.Length; i++)
            {
                if (indices[i] >= dimensions[i]) throw new IndexOutOfRangeException($"The index {indices[i]} for dimension {i} exceeds the size of the dimension {dimensions[i]}.");
            }
            return source.GetValue(ArrayUtilities.GetIndex(source.strides, indices, broadcastedDims));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        set
        {
            if (indices.Length == 1 && Rank == 0 && indices[0] == 0)
            {
                SetValue(0, value);
                return;
            }
            for (int i = 0; i < indices.Length; i++)
            {
                if (indices[i] >= dimensions[i]) throw new IndexOutOfRangeException($"The index {indices[i]} for dimension {i} exceeds the size of the dimension {dimensions[i]}.");
            }
            this.source.SetValue(ArrayUtilities.GetIndex(source.strides, indices, broadcastedDims), value);
        }
    }

    public override Tensor<T> Clone() => new BroadcastedTensor<T>(source, dimensions, broadcastedDims);
        
    public override Tensor<TResult> CloneEmpty<TResult>(ReadOnlySpan<int> dimensions) => new DenseTensor<TResult>(dimensions);  

    public override Tensor<T> Reshape(ReadOnlySpan<int> dims)
    {
        throw new NotSupportedException();
    }
    

    public override Tensor<T> InsertDim(int dim)
    {
        if (dim >= Rank) throw new ArgumentException(nameof(dim));
        var dims = this.dimensions.ToList();
        dims.Insert(dim, 1);
        var bdims = broadcastedDims.Copy();
        for(int i = 0; i < bdims.Length; i++)
        {
            if (bdims[i] >= dim)
            {
                bdims[i] += 1;
            }
        }
        return new BroadcastedTensor<T>(source.InsertDim(dim), dims.ToArray(), bdims);
    }

    public override Tensor<T> RemoveDim(int dim)
    {
        if (dim >= Rank) throw new ArgumentException(nameof(dim));
        if (dimensions[dim] != 1) throw new ArgumentException(nameof(dim), $"Can only remove a dimension of size 1. Dimension {dim} has size {dimensions[dim]}.");
        var dims = dimensions.ToList();
        dims.RemoveAt(dim);
        var bdims = broadcastedDims.Copy();
        for (int i = 0; i < bdims.Length; i++)
        {
            if (bdims[i] >= dim)
            {
                bdims[i] -= 1;
            }
        }
        return new BroadcastedTensor<T>(source.RemoveDim(dim), dims.ToArray(), bdims);
    }

    public override BroadcastedTensor<T> BroadcastDim(int dim, int size)
    {
        if (dim >= Rank)
        {
            throw new ArgumentException($"The specified dimension {dim} exceeds the tensor rank.");
        }
        else if (dimensions[dim] != 1)
        {
            throw new ArgumentException($"Dimension {dim} must be of size 1 to broadcast.");
        }
        else
        {
            dimensions[dim] = size;
            return new BroadcastedTensor<T>(source, dimensions, broadcastedDims.Append(dim).ToArray());
        }
    }
    #endregion

    #endregion

    #region Fields
    public readonly Tensor<T> source;
    public int[] broadcastedDims;
    #endregion
}

