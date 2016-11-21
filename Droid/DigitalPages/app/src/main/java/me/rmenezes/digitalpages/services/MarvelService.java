package me.rmenezes.digitalpages.services;

import retrofit2.Call;
import retrofit2.http.GET;
import retrofit2.http.Path;
import retrofit2.http.Query;

import java.util.Objects;

/**
 * Created by raul on 14/11/16.
 */
public interface MarvelService {
    @GET("https://gateway.marvel.com:443/v1/public/characters?orderBy=name")
    Call<Object> getCharactersByName(@Query("apikey") String apikey, @Query("name") String name , @Query("ts")String ts, @Query("hash")String hash);

    @GET("https://gateway.marvel.com:443/v1/public/characters")
    Call<Object> getCharacters(@Query("apikey") String apikey, @Query("ts")String ts, @Query("hash")String hash);

    @GET("/{id}")
    Call<Object> getDetails(@Path("id") long id, @Query("apikey") String apikey, @Query("ts")String ts, @Query("hash")String hash);

    @GET("/{id}/comics?orderBy=title&format=comic&formatType=comic&noVariants=true")
    Call<Object> getComicsByIdCharacters(@Path("id") long id, @Query("apikey") String apikey, @Query("ts")String ts, @Query("hash")String hash);
}
