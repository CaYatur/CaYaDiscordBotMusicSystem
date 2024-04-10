using Discord;
using Discord.Audio;
using Discord.WebSocket;
using NAudio.Wave;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoConverter;

namespace CaYaBotMusicSystem
{
    public partial class Form1 : Form
    {
        private DiscordSocketClient _client;
        private IAudioClient _audioClient;
        //private ulong VOICE_CHANNEL_ID = 1;
        private ulong VOICE_CHANNEL_ID;
        //private string VOICE_CHANNEL_ID;
        private bool _isPlaying = false;
        private bool _isPaused = false;
        private string GetTOKEN = null;
        private string BotName = null;

        public Form1()
        {
            InitializeComponent();
        }
        private string _tempFolderPath = Path.Combine(Path.GetTempPath(), "CaYaBotMusicSystemTemp");

        private async void Form1_Load(object sender, EventArgs e)
        {

            Directory.CreateDirectory(_tempFolderPath);




            // Ge�ici dosyalardan de�erleri y�kle
            txtChannelId.Text = LoadTextBoxValueFromTempFile("channelId.txt");
            txtMusicUrl.Text = LoadTextBoxValueFromTempFile("musicUrl.txt");
            textBox1.Text = LoadTextBoxValueFromTempFile("token.txt");

            GC.Collect();
        }

        private void SaveTextBoxValueToTempFile(TextBox textBox, string fileName)
        {
            string tempFilePath = Path.Combine(_tempFolderPath, fileName);
            File.WriteAllText(tempFilePath, textBox.Text);
        }

        private string LoadTextBoxValueFromTempFile(string fileName)
        {
            string tempFilePath = Path.Combine(_tempFolderPath, fileName);
            if (File.Exists(tempFilePath))
            {
                return File.ReadAllText(tempFilePath);
            }
            return string.Empty;
        }



        private Task LogAsync(LogMessage log)
        {
            Console.WriteLine(log.Message);
            if (label4.InvokeRequired)
            {
                label4.Invoke(new MethodInvoker(delegate
                {
                    label4.Text = $"Bot Kullan�c� Ad�: {BotName}";
                }));
            }
            else
            {
                label4.Text = $"Bot Kullan�c� Ad�: {BotName}";
            }
            return Task.CompletedTask;
        }



        private async void btnConnect_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;

            var voiceChannel = _client.GetChannel(VOICE_CHANNEL_ID) as IVoiceChannel;
            if (voiceChannel == null)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                MessageBox.Show("Hatal� Kanal ID'si.");
                return;
            }

            _audioClient = await voiceChannel.ConnectAsync();
            MessageBox.Show(BotName + " Ses Kanal�na Kat�ld�.");
        }

        private async void btnDisconnect_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;

            if (_audioClient != null)
            {
                await _audioClient.StopAsync();
                MessageBox.Show(BotName + " Ses Kanal�ndan Ayr�ld�.");
            }
            else
            {
                MessageBox.Show(BotName + " Zaten Ba�ka Bir Ses Kanal�nda veya Seste De�il.");
            }
        }

        private async void btnPlay_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button3.Enabled = false;
                button5.Enabled = true;
                var voiceChannel = _client.GetChannel(VOICE_CHANNEL_ID) as IVoiceChannel;
                if (voiceChannel == null)
                {
                    button3.Enabled = true;
                    button5.Enabled = false;
                    MessageBox.Show("Hatal� Ses Kanal� ID'si.");
                    return;
                }

                _audioClient = await voiceChannel.ConnectAsync();

                string audioFilePath = txtMusicUrl.Text;

                if (File.Exists(audioFilePath))
                {
                    GC.Collect();
                    string wavFilePath = Path.Combine(Path.GetTempPath(), "temp.wav");

                    if (Path.GetExtension(audioFilePath).Equals(".mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        // MP3 dosyas�n� WAV format�na d�n��t�r
                        ConvertMP3toWAV(audioFilePath, wavFilePath);
                        audioFilePath = wavFilePath;
                    }
                    else if (Path.GetExtension(audioFilePath).Equals(".mp4", StringComparison.OrdinalIgnoreCase))
                    {
                        // MP4 dosyas�n� WAV format�na d�n��t�r
                        ConvertMP4toWAV(audioFilePath, wavFilePath);
                        audioFilePath = wavFilePath;
                    }
                    else if (Path.GetExtension(audioFilePath).Equals(".wav", StringComparison.OrdinalIgnoreCase))
                    {
                        // WAV dosyas� oldu�unda herhangi bir d�n���m gerekmez
                        wavFilePath = audioFilePath;
                    }
                    else
                    {
                        MessageBox.Show("Desteklenmeyen dosya format�!");
                        return;
                    }

                    // WAV dosyas�n� oynat
                    _isPlaying = true;
                    var audioStream = _audioClient.CreatePCMStream(AudioApplication.Music);
                    using (var audioFile = File.OpenRead(audioFilePath))
                    {
                        try
                        {
                            await audioFile.CopyToAsync(audioStream);
                            await audioStream.FlushAsync();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while copying audio: {ex.Message}");
                        }
                    }
                    _isPlaying = false;

                    // �ark� �alma tamamland� uyar�s�
                    //MessageBox.Show("�ark� �alma tamamland�!");
                    button3.Enabled = true;
                    button5.Enabled = false;

                }
                else
                {
                    MessageBox.Show("B�yle bir dosya bulunamad�!");
                }
            }
            else
            {
                button3.Enabled = false;
                button5.Enabled = true;
                var voiceChannel = _client.GetChannel(VOICE_CHANNEL_ID) as IVoiceChannel;
                if (voiceChannel == null)
                {
                    button3.Enabled = true;
                    button5.Enabled = false;
                    MessageBox.Show("Hatal� Ses Kanal� ID'si.");
                    return;
                }

                _audioClient = await voiceChannel.ConnectAsync();

                string audioFilePath = txtMusicUrl.Text;

                if (File.Exists(audioFilePath))
                {
                    GC.Collect();
                    string wavFilePath = Path.Combine(Path.GetTempPath(), "temp.wav");

                    if (Path.GetExtension(audioFilePath).Equals(".mp3", StringComparison.OrdinalIgnoreCase))
                    {
                        // MP3 dosyas�n� WAV format�na d�n��t�r
                        ConvertMP3toWAV(audioFilePath, wavFilePath);
                        audioFilePath = wavFilePath;
                    }
                    else if (Path.GetExtension(audioFilePath).Equals(".mp4", StringComparison.OrdinalIgnoreCase))
                    {
                        // MP4 dosyas�n� WAV format�na d�n��t�r
                        ConvertMP4toWAV(audioFilePath, wavFilePath);
                        audioFilePath = wavFilePath;
                    }
                    else if (Path.GetExtension(audioFilePath).Equals(".wav", StringComparison.OrdinalIgnoreCase))
                    {
                        // WAV dosyas� oldu�unda herhangi bir d�n���m gerekmez
                        wavFilePath = audioFilePath;
                    }
                    else
                    {
                        MessageBox.Show("Desteklenmeyen dosya format�!");
                        return;
                    }

                    // WAV dosyas�n� oynat
                    _isPlaying = true;
                    var audioStream = _audioClient.CreatePCMStream(AudioApplication.Music);
                    using (var audioFile = new WaveFileReader(wavFilePath))
                    {
                        try
                        {
                            var waveFormat = new WaveFormat(48000, 16, 2); // Discord i�in uygun WAV format� (48000 Hz, 16-bit, stereo)
                            var formatConvertedStream = new WaveFormatConversionStream(waveFormat, audioFile);

                            byte[] buffer = new byte[formatConvertedStream.WaveFormat.AverageBytesPerSecond / 2];
                            int bytesRead;
                            while ((bytesRead = formatConvertedStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                await audioStream.WriteAsync(buffer, 0, bytesRead);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred while copying audio: {ex.Message}");
                        }
                    }
                    _isPlaying = false;

                    // �ark� �alma tamamland� uyar�s�
                    //MessageBox.Show("�ark� �alma tamamland�!");
                    button3.Enabled = true;
                    button5.Enabled = false;
                }
                else
                {
                    MessageBox.Show("B�yle bir dosya bulunamad�!");
                }
            }
            
        }




        private void ConvertMP3toWAV(string mp3FilePath, string wavFilePath)
        {
            using (var mp3Reader = new Mp3FileReader(mp3FilePath))
            {
                WaveFileWriter.CreateWaveFile(wavFilePath, mp3Reader);
            }
            Console.WriteLine("MP3 converted to WAV.");
        }

        private void ConvertMP4toWAV(string mp4FilePath, string wavFilePath)
        {
            var ffMpeg = new NReco.VideoConverter.FFMpegConverter();
            ffMpeg.ConvertMedia(mp4FilePath, wavFilePath, "wav");
            Console.WriteLine("MP4 converted to WAV.");
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (_isPlaying)
            {
                // Duraklatma i�lemini ger�ekle�tir
                _isPaused = !_isPaused;
                MessageBox.Show(_isPaused ? "Playback paused." : "Playback resumed.");
            }
            else
            {
                MessageBox.Show("No music is playing.");
            }
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button5.Enabled = false;
            if (_audioClient != null)
            {
                try
                {
                    await _audioClient.StopAsync();
                    //MessageBox.Show("Oynat�c� Durduruldu!");
                    button3.Enabled = false;
                    button5.Enabled = true;
                    GC.Collect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while stopping playback: {ex.Message}");
                }

            }
            else
            {
                button3.Enabled = true;
                button5.Enabled = false;
                MessageBox.Show("�ark� zaten oynat�lm�yor!");
            }
            button3.Enabled = true;
            button5.Enabled = true;
        }



        private async void button6_Click(object sender, EventArgs e)
        {
            GetTOKEN = textBox1.Text;
            textBox1.Visible = false;
            button6.Visible = false;
            label1.Visible = false;
            _client = new DiscordSocketClient();

            _client.Log += LogAsync;
            _client.Ready += ReadyAsync;

            await _client.LoginAsync(TokenType.Bot, GetTOKEN);
            await _client.StartAsync();

            panel1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            GC.Collect();
        }

        private async Task ReadyAsync()
        {
            Console.WriteLine($"{_client.CurrentUser} is connected!");
            string botUsername = _client.CurrentUser.Username;
            BotName = botUsername;

            await _client.SetGameAsync("CaYaBot Services");
            await _client.SetStatusAsync(UserStatus.Idle);

            //MessageBox.Show($"Bot username: {botUsername}");
        }


        private void txtChannelId_TextChanged(object sender, EventArgs e)
        {
            if (ulong.TryParse(txtChannelId.Text, out ulong channelId))
            {
                VOICE_CHANNEL_ID = channelId;
            }
            SaveTextBoxValueToTempFile(txtChannelId, "channelId.txt");

        }
        private bool cl1 = false;
        private bool cl2 = false;
        private void txtChannelId_Click(object sender, EventArgs e)
        {
            if (cl1 == false)
            {
                txtChannelId.Text = "";
                cl1 = true;
            }

        }

        private void txtMusicUrl_Click(object sender, EventArgs e)
        {
            if (cl2 == false)
            {
                txtMusicUrl.Text = "";
                cl2 = true;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            string link = "https://discord.gg/ybRvvC4KTp";

            try
            {
                // Varsay�lan web taray�c�s�n� kullanarak linki a�ma
                Process.Start(new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Link a��lamad�: " + ex.Message);
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.BlueViolet;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = System.Drawing.Color.White;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SaveTextBoxValueToTempFile(textBox1, "token.txt");
        }

        private void txtMusicUrl_TextChanged(object sender, EventArgs e)
        {
            SaveTextBoxValueToTempFile(txtMusicUrl, "musicUrl.txt");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // Ge�ici dosyalar�n bulundu�u klas�r� kontrol et ve t�m dosyalar� sil
                if (Directory.Exists(_tempFolderPath))
                {
                    foreach (string filePath in Directory.GetFiles(_tempFolderPath))
                    {
                        File.Delete(filePath);
                    }
                    // Ge�ici klas�r� sil
                    Directory.Delete(_tempFolderPath);
                    MessageBox.Show("BA�ARIYLA TEM�ZLEND�! L�tfen uygulamay� yeniden ba�lat�n.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while cleaning up temporary files: {ex.Message}");
            }
        }
    }
}
