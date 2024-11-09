import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-audio-player',
  templateUrl: './audio-player.component.html',
  styleUrls: ['./audio-player.component.less'],
})
export class AudioPlayerComponent implements OnInit {
  @Input() recommendations: any[] = [];
  currentTrack: any = {}; // Object to hold the current track information
  audio = new Audio(); // Create a new Audio instance for playback
  isPlaying = false; // Boolean to track play/pause state
  currentTime = 0; // Current playback time
  progress = 0; // Progress for the progress bar
  trackDuration = 0; // Track duration (total time)
  currentTrackIndex: number | null = null; // Track the index of the current track

  constructor() {}

  ngOnInit(): void {
    if (this.recommendations.length) {
      this.playTrack(0);
    }
  }

  // Method to play a selected track
  playTrack(index: number) {
    const track = this.recommendations[index];

    // Update current track details
    this.currentTrack = {
      name: track.name,
      artist: track.artistName,
      albumArt: track.albumImageUrl, // Use AlbumImageUrl for album art
      url: track.externalUrl, // Assuming externalUrl is the track URL or Spotify preview URL
    };
    this.currentTrackIndex = index;
    // Check if the previewUrl exists
    if (track.previewUrl) {
      // Set the audio source to the preview URL
      this.audio.src = track.previewUrl;
      this.audio.load(); // Load the track preview
      this.audio.play(); // Play the track preview

      // Set track duration once it's loaded
      this.audio.onloadedmetadata = () => {
        this.trackDuration = this.audio.duration;
      };

      // Update the current time and progress bar while playing
      this.audio.ontimeupdate = () => {
        this.currentTime = this.audio.currentTime;
        this.progress = (this.currentTime / this.trackDuration) * 100;
      };

      // Set playing state to true
      this.isPlaying = true;
    } else {
      console.error("Preview URL not available for this track.");
    }
  }

  // Method to toggle play/pause
  togglePlayPause() {
    if (this.isPlaying) {
      this.audio.pause(); // Pause the track
    } else {
      this.audio.play(); // Play the track
    }
    this.isPlaying = !this.isPlaying;
  }

  // Method to go to the next track
  nextTrack() {
    const nextIndex = (this.recommendations.indexOf(this.currentTrack) + 1) % this.recommendations.length;
    this.playTrack(nextIndex); // Play next track
  }

  // Method to go to the previous track
  previousTrack() {
    const previousIndex = (this.recommendations.indexOf(this.currentTrack) - 1 + this.recommendations.length) % this.recommendations.length;
    this.playTrack(previousIndex); // Play previous track
  }

  // Method to seek through the track
  seekTrack(event: any) {
    const seekTime = (event.target.value / 100) * this.trackDuration;
    this.audio.currentTime = seekTime;
  }
}
