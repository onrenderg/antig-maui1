from flask import Flask, jsonify

app = Flask(__name__)

@app.route('/initial', methods=['GET'])
def get_initial_config():
    data = [
        {
            "Key": "welcome_message",
            "Value": "Welcome to Him Kavach (API)"
        },
        {
            "Key": "api_status",
            "Value": "Online"
        },
        {
            "Key": "feature_flags",
            "Value": "dark_mode=true,beta=false"
        }
    ]
    return jsonify(data)

if __name__ == '__main__':
    # Host 0.0.0.0 allows access from external devices (like Android Emulator)
    app.run(host='0.0.0.0', port=8080)
