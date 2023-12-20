﻿namespace Lokad.Onnx.Backend;

public enum OpType
{
    Abs,
    Acos,
    Acosh,
    Add,
    And,
    ArgMax,
    ArgMin,
    Asin,
    Asinh,
    Atan,
    Atanh,
    AveragePool,
    BatchNormalization,
    BitShift,
    BitwiseAnd,
    BitwiseNot,
    BitwiseOr,
    BitwiseXor,
    Cast,
    Ceil,
    Col2Im,
    Compress,
    Concat,
    ConcatFromSequence,
    Constant,
    ConstantOfShape,
    Conv,
    ConvInteger,
    ConvTranspose,
    Cos,
    Cosh,
    CumSum,
    DFT,
    DeformConv,
    DepthToSpace,
    DequantizeLinear,
    Det,
    Div,
    Dropout,
    Einsum,
    Equal,
    Erf,
    Exp,
    Expand,
    EyeLike,
    Flatten,
    Floor,
    GRU,
    Gather,
    GatherElements,
    GatherND,
    Gemm,
    GlobalAveragePool,
    GlobalLpPool,
    GlobalMaxPool,
    Greater,
    GridSample,
    Hardmax,
    Identity,
    If,
    ImageDecoder,
    InstanceNormalization,
    IsInf,
    IsNaN,
    LRN,
    LSTM,
    Less,
    Log,
    Loop,
    LpNormalization,
    LpPool,
    MatMul,
    MatMulInteger,
    Max,
    MaxPool,
    MaxRoiPool,
    MaxUnpool,
    Mean,
    MelWeightMatrix,
    Min,
    Mod,
    Mul,
    Multinomial,
    Neg,
    NonMaxSuppression,
    NonZero,
    Not,
    OneHot,
    Optional,
    OptionalGetElement,
    OptionalHasElement,
    Or,
    Pad,
    Pow,
    QLinearConv,
    QLinearMatMul,
    QuantizeLinear,
    RNN,
    RandomNormal,
    RandomNormalLike,
    RandomUniform,
    RandomUniformLike,
    Reciprocal,
    ReduceMax,
    ReduceMean,
    ReduceMin,
    ReduceProd,
    ReduceSum,
    RegexFullMatch,
    Reshape,
    Resize,
    ReverseSequence,
    RoiAlign,
    Round,
    STFT,
    Scan,
    Scatter,
    ScatterElements,
    ScatterND,
    SequenceAt,
    SequenceConstruct,
    SequenceEmpty,
    SequenceErase,
    SequenceInsert,
    SequenceLength,
    Shape,
    Sigmoid,
    Sign,
    Sin,
    Sinh,
    Size,
    Slice,
    SpaceToDepth,
    Split,
    SplitToSequence,
    Sqrt,
    Squeeze,
    StringConcat,
    StringNormalizer,
    StringSplit,
    Sub,
    Sum,
    Tan,
    Tanh,
    TfIdfVectorizer,
    Tile,
    TopK,
    Transpose,
    Trilu,
    Unique,
    Unsqueeze,
    Upsample,
    Where,
    Xor,
    AffineGrid,
    Bernoulli,
    BlackmanWindow,
    CastLike,
    Celu,
    CenterCropPad,
    Clip,
    DynamicQuantizeLinear,
    Elu,
    Gelu,
    GreaterOrEqual,
    GroupNormalization,
    HammingWindow,
    HannWindow,
    HardSigmoid,
    HardSwish,
    LayerNormalization,
    LeakyRelu,
    LessOrEqual,
    LogSoftmax,
    MeanVarianceNormalization,
    Mish,
    NegativeLogLikelihoodLoss,
    PRelu,
    Range,
    ReduceL1,
    ReduceL2,
    ReduceLogSum,
    ReduceLogSumExp,
    ReduceSumSquare,
    Relu,
    Selu,
    SequenceMap,
    Shrink,
    Softmax,
    SoftmaxCrossEntropyLoss,
    Softplus,
    Softsign,
    ThresholdedRelu,
}
