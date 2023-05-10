# SpotiStore

Spotistore is a small cross-platform utility for generating tracklist spreadsheets from Spotify playlists.
The compact UI allows you to input any playlist ID, then save the playlist's information to a CSV file.  

The playlist information recorded in the CSV includes track names, album names, song artists, release dates, spotify track IDs, added to playlist dates, and Discog links for physical releases.

## Using Spotistore

Currently, you'll need to build your own copy of spotistore to use the app. You'll need to obtain a Spotify API key via [Spotify for Developers](https://developer.spotify.com/). After getting a API key, you'll need to add a API key file to the Models folder (Spotistore/Models) of the project entitled APICredentials.cs.
After creating the file, copy the following code into it and add replace the empty variable values with your client ID and secret:
~~~
  using System;
  using System.Collections.Generic;
  using System.Text;

  namespace SpotiStore.Models
  {
      public class APICredentials
      {
          public static string ClientId = "<REPLACE ME>";
          public static string ClientSecret = "<REPLACE ME>";

      }
  }

~~~
To build the app you will need to have Avalonia 0.9.12 or newer. After building the application, you should be able to simply enter in a Spotify playlist ID, search for the playlist, then generate a CSV.  

## Obtaining Spotify playlist IDs

While there are multiple ways to get a Spotify playlist ID, the easiest way would be to use the [Spotify Web API] (https://open.spotify.com) and navigate to your chosen playlist.  

The Playlist ID is displayed after the last forward slash of the URL and generally looks like this:  2dgjh8B6g70o8Ll3WVD8LG
