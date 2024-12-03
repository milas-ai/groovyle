using Assets.WasapiAudio.Scripts.Unity;
using UnityEngine;

public class ReactBehaviourZ : AudioVisualizationEffect
{
    private Vector3 _originalPosition;
    private Vector3 _originalScale;
    private float _fall = 0;

    // public GameObject Subject;
    public float AudioScale = 5;
    public float Power = 2;
    public int SpectrumBand = 0;
    
    [SerializeField] bool _smoothFall = true;
    public bool smoothFall
        { get => _smoothFall;
        set => _smoothFall = value; }

    [SerializeField, Range(0, 1)] float _fallSpeed = 0.3f;
    public float fallSpeed
        { get => _fallSpeed;
        set => _fallSpeed = value; }

    void Start()
    {
        // _originalScale = Subject.transform.localScale;
        _originalScale = transform.localScale;
    }

    void Update()
    {
        var dt = Time.deltaTime;

        var spectrumData = GetSpectrumData();
        // Debug.Log(spectrumData[SpectrumBand]);
        var audioScale = Mathf.Pow(spectrumData[SpectrumBand] * AudioScale, Power);
        // Debug.Log(audioScale);

        if (_smoothFall)
        {
            var audioFall = audioScale;
            // Hold and fall down animation
            var fallConstant = Mathf.Pow(0.03f * AudioScale, Power);
            _fall += Mathf.Pow(fallConstant, 1 + _fallSpeed * 2) * dt;
            audioFall -= _fall * dt;

            // Pull up by input.
            if (audioFall < audioScale)
            {
                audioFall = audioScale;
                _fall = 0;
            }
            else
            {
                Debug.Log("falling");
            }
            audioScale = audioFall;
        }

        var newScale = new Vector3(_originalScale.x, _originalScale.y, _originalScale.z + audioScale);
        // Subject.transform.localScale = newScale;
        transform.localScale = newScale;
    }
}
