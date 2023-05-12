using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace GameToEarnLegos
{
    public class AudioPlaybackEngine : IDisposable
    {
        private readonly IWavePlayer outputDevice;
        private readonly MixingSampleProvider mixer;
        private readonly WaveFormat format;

        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2)
        {
            var waveOutEvent = new WaveOutEvent();
            waveOutEvent.DeviceNumber = -1;
            outputDevice = waveOutEvent;
            format = WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount);
            mixer = new MixingSampleProvider(format);
            mixer.ReadFully = true;
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public WaveFormat Format => format;

        public float MasterVolume
        {
            get { return outputDevice.Volume; }
            set { outputDevice.Volume = value; }
        }


        public void PlaySound(string fileName)
        {
            var input = new AudioFileReader(fileName);
            PlaySoundInstance(new AutoDisposeFileReader(input));
        }

        private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
        {
            if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
            {
                return input;
            }
            if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                return new MonoToStereoSampleProvider(input);
            }
            throw new NotImplementedException("Not yet implemented this channel count conversion");
        }

        public void PlaySound(CachedSound sound)
        {
            PlaySoundInstance(new CachedSoundSampleProvider(sound));
        }

        public void PlaySoundInstance(ISampleProvider soundInstance)
        {
            mixer.AddMixerInput(ConvertToRightChannelCount(soundInstance));
        }

        public void StopSoundInstance(ISampleProvider soundInstance)
        {
            mixer.RemoveMixerInput(soundInstance);
        }

        public void Dispose()
        {
            outputDevice.Dispose();
        }

        //[ThreadStatic]
        //public static readonly AudioPlaybackEngine Instance = new AudioPlaybackEngine(44100, 2);
    }

    public class CachedSound
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }

        public static CachedSound Create(string audioFileName, WaveFormat targetFormat)
        {
            using (var audioFileReader = new AudioFileReader(audioFileName))
            {
                return Create(new SampleToWaveProvider(audioFileReader), targetFormat);
            }
        }

        public static CachedSound Create(Stream sound, string fileExtension, WaveFormat targetFormat)
        {
            CachedSound cachedSound = null;
            IWaveProvider waveProvider = null;
            try
            {
                if (fileExtension?.ToLower() == ".mp3")
                    waveProvider = new Mp3FileReader(sound);
                else if (fileExtension?.ToLower() == ".wav")
                    waveProvider = new WaveFileReader(sound);
                else if (fileExtension?.ToLower()?.StartsWith(".aif") ?? false)
                    waveProvider = new AiffFileReader(sound);

                if (waveProvider != null)
                    cachedSound = Create(waveProvider, targetFormat);
            } 
            finally
            {
                if (waveProvider != null && waveProvider is IDisposable) (waveProvider as IDisposable).Dispose();
            }
            return cachedSound;
        }

        private static CachedSound Create(IWaveProvider wavProvider, WaveFormat targetFormat)
        {
            var cachedSound = new CachedSound();
            using (var resampler = new MediaFoundationResampler(wavProvider, targetFormat))
            {
                var waveToSampleProvider = new WaveToSampleProvider(resampler);
                var wholeFile = new List<float>();
                var readBuffer = new float[waveToSampleProvider.WaveFormat.SampleRate * waveToSampleProvider.WaveFormat.Channels];
                int samplesRead;
                while ((samplesRead = waveToSampleProvider.Read(readBuffer, 0, readBuffer.Length)) > 0)
                {
                    wholeFile.AddRange(readBuffer.Take(samplesRead));
                }
                cachedSound.WaveFormat = waveToSampleProvider.WaveFormat;
                cachedSound.AudioData = wholeFile.ToArray();
            }
            return cachedSound;
        }
    }

    public class CachedSoundSampleProvider : ISampleProvider
    {
        private readonly CachedSound _cachedSound;
        private long _position = 0;
        private float _volume = 1f;
        private bool _loopingEnabled = true;
        private bool _stopASAP = false;



        public CachedSoundSampleProvider(CachedSound cachedSound)
        {
            this._cachedSound = cachedSound;
        }

        public long Position { get => this._position; set => _position = value; }
        public float Volume { get => this._volume; set => _volume = value; }
        public bool LoopingEnabled { get => this._loopingEnabled; set => _loopingEnabled = value; }
        public bool StopASAP { get => this._stopASAP; set => _stopASAP = value; }

        public int Read(float[] buffer, int offset, int count)
        {
            //var availableSamples = _cachedSound.AudioData.Length - _position;
            //var samplesToCopy = Math.Min(availableSamples, count);
            //Array.Copy(_cachedSound.AudioData, _position, buffer, offset, samplesToCopy);
            //_position += samplesToCopy;
            //return (int)samplesToCopy;
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                if (StopASAP)
                    return 0;
                // we have reached the end of the file
                if (_cachedSound.AudioData.Length == Position)
                {
                    if (LoopingEnabled)
                        _position = 0; // reset position if looping enabled
                    else
                        return totalBytesRead; // otherwise, stop reading.
                }

                // copy data
                buffer[totalBytesRead + offset] = _cachedSound.AudioData[Position] * Volume;

                ++_position;
                ++totalBytesRead;
            }
            return totalBytesRead;
        }

        public WaveFormat WaveFormat { get { return _cachedSound.WaveFormat; } }
    }

    public class AutoDisposeFileReader : ISampleProvider
    {
        private readonly AudioFileReader reader;
        private bool isDisposed;
        public AutoDisposeFileReader(AudioFileReader reader)
        {
            this.reader = reader;
            this.WaveFormat = reader.WaveFormat;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if (isDisposed)
                return 0;
            int read = reader.Read(buffer, offset, count);
            if (read == 0)
            {
                reader.Dispose();
                isDisposed = true;
            }
            return read;
        }

        public WaveFormat WaveFormat { get; private set; }
    }

    public enum GameSounds
    {
        MenuMusic,
        GameMusic,
        LastLevelMusic,
        ShootGun1
    }

    public class SoundManager
    {
        private Dictionary<GameSounds, CachedSound> _soundsInMemory = new Dictionary<GameSounds, CachedSound>();
        private List<CachedSoundSampleProvider> _soundsInstances = new List<CachedSoundSampleProvider>();

        public SoundManager()
        {

        }
        public void unloadSound(GameSounds soundName)
        {
            if (_soundsInMemory.ContainsKey(soundName))
                _soundsInMemory.Remove(soundName);
        }

        public void loadSound(GameSounds soundName, string fileName, WaveFormat format)
        {
            _soundsInMemory.Add(soundName, CachedSound.Create(fileName, format));
        }

        public void loadSound(GameSounds soundName, Stream stream, string fileExtension, WaveFormat format)
        {
            _soundsInMemory.Add(soundName, CachedSound.Create(stream, fileExtension, format));
        }

        public CachedSound getLoadedSound(GameSounds soundName)
        {
            if (_soundsInMemory.ContainsKey(soundName))
                return _soundsInMemory[soundName];
            return null;
        }

        public CachedSoundSampleProvider createSoundInstance(GameSounds soundName, float volume = 1f, bool enableLooping = true)
        {
            CachedSoundSampleProvider sound = new CachedSoundSampleProvider(getLoadedSound(soundName));
            sound.Volume = volume;
            sound.LoopingEnabled = enableLooping;
            //_soundsInstances.Add(sound);
            return sound;
        }
    }
}
