package me.rmenezes.digitalpages;

import android.os.AsyncTask;
import android.os.Looper;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;
import me.rmenezes.digitalpages.services.MarvelService;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

public class MainActivity extends AppCompatActivity {

    private final String apiKey = "d5c2d01b2fa66ee7eea7f6ee9c6c66fe";
    private final String apiUrl = "https://gateway.marvel.com:443/v1/public/characters/";
    private final String ts = "1234";
    private final String apiPrivateKey = "8c98082304f2f476b6a49509befff8feb8c1f02c";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        String hash = md5(ts + apiPrivateKey + apiKey);
        final Characters service = new Characters(apiKey, apiUrl, ts, hash);

        Button btGetData = (Button) findViewById(R.id.btGetAll);
        btGetData.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AsyncTask.execute(new Runnable() {
                    @Override
                    public void run() {
                        String response = service.getAll("");

                        Log.d("MARVEL", response);

//                        if(response.isEmpty()) {
//                            MainActivity.this.showToast("No Content found on server");
//                        } else {
//                            MainActivity.this.showToast(response);
//                        }
                    }
                });
            }
        });
    }

    public void showToast(String message) {
        Toast.makeText(getApplicationContext(), message, Toast.LENGTH_LONG).show();
    }

    public static final String md5(final String s) {
        final String MD5 = "MD5";
        try {
            // Create MD5 Hash
            MessageDigest digest = java.security.MessageDigest
                    .getInstance(MD5);
            digest.update(s.getBytes());
            byte messageDigest[] = digest.digest();

            // Create Hex String
            StringBuilder hexString = new StringBuilder();
            for (byte aMessageDigest : messageDigest) {
                String h = Integer.toHexString(0xFF & aMessageDigest);
                while (h.length() < 2)
                    h = "0" + h;
                hexString.append(h);
            }
            return hexString.toString();

        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
        return "";
    }
}
