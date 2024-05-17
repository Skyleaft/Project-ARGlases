using System;
using System.Collections.Generic;

[Serializable]
public class BetaFace
{
    public FaceMedia media;
    public string recognize;
}

[Serializable]
public class FaceMedia
{
    public string checksum;
    public string duration;
    public List<Faces> faces;
    public string media_uuid;
}

[Serializable]
public class Faces
{
    public string face_uuid;
    public string media_uuid;
    public List<FaceTags> tags;
}
