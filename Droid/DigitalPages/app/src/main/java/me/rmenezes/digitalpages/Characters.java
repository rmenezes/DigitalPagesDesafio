package me.rmenezes.digitalpages;

import com.google.gson.Gson;
import me.rmenezes.digitalpages.services.MarvelService;
import retrofit2.Call;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

import java.io.IOException;

/**
 * Created by raul on 14/11/16.
 */
public class Characters {
    private final String apiKey;
    private final String apiUrl;
    private final String ts;
    private final String hash;
    private final MarvelService service;

    public Characters(String apiKey, String apiUrl, String ts, String hash) {
        this.apiKey = apiKey;
        this.apiUrl = apiUrl;
        this.ts = ts;
        this.hash = hash;

        Retrofit retrofit;

        retrofit = new Retrofit.Builder()
                .baseUrl(apiUrl)
                .addConverterFactory(GsonConverterFactory.create())
                .build();


        service = retrofit.create(MarvelService.class);
    }

    public String getAll(String name) {
        try {
            Response<Object> response;
            Call<Object> call;

            if(!name.isEmpty()) {
                call = service.getCharactersByName(apiKey, name, ts, hash);
            } else {
                call = service.getCharacters(apiKey, ts, hash);
            }

            response = call.execute();

            if(!response.isSuccessful())
                return response.message();

            Gson gson = new Gson();

            return gson.toJson(response.body());

        } catch (IOException e) {
            return e.getMessage();
        }
        catch (RuntimeException e) {
            return e.getMessage();
        }
    }

    public String getDetails(int id) {
//        try {
//            Response<String> response = service.details(id, apiUrl).execute();
//
//            if(!response.isSuccessful())
//                return "";
//
//            return response.body();
//
//        } catch (IOException e) {
//            e.printStackTrace();
//
//            return "";
//        }

        return "";
    }

    public String getApiKey() {
        return apiKey;
    }

    public String getApiUrl() {
        return apiUrl;
    }
}
