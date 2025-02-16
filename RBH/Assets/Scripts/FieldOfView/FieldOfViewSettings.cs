using UnityEngine;

[CreateAssetMenu(fileName = "MyFOVSettings", menuName = "Field Of View/Settings")]
public class FieldOfViewSettings : FieldOfViewSettingsBase, IFieldOfViewSettings
{
    [field: SerializeField]
    [field: Tooltip("Must be greater than zero")]
    public float FrontViewAngle { get; set; } = 70.0f;

    [field: SerializeField]
    [field: Tooltip("Cannot be negative")]
    public float FrontViewDistance { get; set; } = 5.0f;

    [field: SerializeField]
    [field: Tooltip("Additional rays used to generate the mesh. " +
        "The higher the value, the more detailed the mesh, but also slower generation! " +
        "Cannot be negative")]
    public int AdditionalFrontRayCount { get; set; } = 0;

    [field: SerializeField]
    [field: Tooltip("Cannot be negative")]
    public float AroundViewDistance { get; set; } = 1.0f;

    [field: SerializeField]
    [field: Tooltip("Additional rays used to generate the mesh. " +
        "The higher the value, the more detailed the mesh, but also slower generation! " +
        "Cannot be negative")]
    public int AdditionalAroundRayCount { get; set; } = 0;

    public override IFieldOfViewSettings CreateSettings() => this;
}
